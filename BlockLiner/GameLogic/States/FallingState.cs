using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BlockLiner.GameLogic.Blocks;

namespace BlockLiner.GameLogic.States
{
    class FallingState : BlockLinerState
    {

        private double _fallingTime;
        private double _seconds;

        public override Type StateType
        {
            get
            {
                return Type.Falling;
            }
        }

        public FallingState(double seconds)
        {
            _fallingTime = 0;
            _seconds = seconds;
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            // Manage rotation and moving
            _fallingTime += delta.ElapsedGameTime.TotalSeconds;
            if(_fallingTime > _seconds)
            {
                _fallingTime = 0;
                return FallingProcess(gamestate);
            }
            return this;
        }

        private BlockLinerState FallingProcess(IBlockLiner gamestate)
        {
            List<Block> fellBlocks = new List<Block>();

            int xLength = gamestate.GameArea.GetLength(0);
            int yLength = gamestate.GameArea.GetLength(1);

            bool revert = false;

            for (int y = yLength - 1; y >= 0; y--)
            {
                for (int x = 0; x < xLength; x++)
                {
                    Block b = gamestate.GameArea[x, y];
                    if (b != null && b.Falling)
                    {
                        if (CanFall(gamestate.GameArea, b))
                        {
                            FallBlock(gamestate.GameArea, b);
                            fellBlocks.Add(b);
                        }
                        else
                        {
                            b.Falling = false;
                            revert = true;
                        }
                    }
                }
            }

            if (revert)
            {
                RevertFalling(gamestate.GameArea, fellBlocks);
                return gamestate.GetStateInstance(Type.Checking);
            }
            return this;
        }

        private static bool CanFall(Block[,] gameArea, Block b)
        {
            int xToCheck = (int)b.X;
            int yToCheck = (int)b.Y + 1;
            return yToCheck < gameArea.GetLength(1) && gameArea[xToCheck, yToCheck] == null;
        }

        private static void FallBlock(Block[,] gameArea, Block b)
        {
            // compute new location
            int xNewPos = (int)b.X;
            int yNewPos = (int)b.Y + 1;

            // move block
            gameArea[xNewPos, yNewPos] = gameArea[xNewPos, yNewPos - 1];
            gameArea[xNewPos, yNewPos - 1] = null;

            // update block location
            gameArea[xNewPos, yNewPos].X = xNewPos;
            gameArea[xNewPos, yNewPos].Y = yNewPos;
        }

        private static void RevertFalling(Block[,] gameArea, List<Block> fellBlocks)
        {
            foreach (Block b in fellBlocks)
            {
                gameArea[(int)b.X, (int)b.Y] = null;
                b.Y -= 1;
                b.Falling = false;
            }
            foreach(Block b in fellBlocks)
            {
                gameArea[(int)b.X, (int)b.Y] = b;
            }
        }
    }
}
