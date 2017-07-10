using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BlockLiner.GameLogic.Blocks;
using Microsoft.Xna.Framework.Input;

namespace BlockLiner.GameLogic.States
{
    class FallingState : BlockLinerState
    {

        private enum Direction
        {
            Left,
            Right,
            Down
        }

        private const double _KEYPOLLINGTIME = 0.1;

        private double _fallingTime;
        private double _seconds;
        private double _inputElapsedTime;

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
            _inputElapsedTime = 0;
            _seconds = seconds;
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            _fallingTime += delta.ElapsedGameTime.TotalSeconds;
            _inputElapsedTime += delta.ElapsedGameTime.TotalSeconds;

            // Manage rotation and moving
            if (_inputElapsedTime > _KEYPOLLINGTIME)
            {
                HandleInput();
            }

            if (_fallingTime > _seconds)
            {
                _fallingTime = 0;
                return FallingProcess(gamestate);
            }
            return this;
        }

        #region InputHandling
        private void HandleInput()
        {
            KeyboardState kbs = Keyboard.GetState();
            if(kbs.IsKeyDown(Keys.Left))
            {

            }
        }
        #endregion

        #region Common

        private static bool IsAbleToMove(Block b, Direction direction, Block[,] gameArea)
        {
            int maxX = gameArea.GetLength(0);
            int maxY = gameArea.GetLength(1);

            int xToCheck = (int)b.X;
            int yToCheck = (int)b.Y;

            switch(direction)
            {
                case Direction.Down:
                    yToCheck++;
                    break;
                case Direction.Left:
                    xToCheck--;
                    break;
                case Direction.Right:
                    xToCheck++;
                    break;
            }
            return xToCheck >= 0 && xToCheck < maxX && yToCheck < maxY && gameArea[xToCheck, yToCheck] == null;
        }

        private static void MoveBlock(Block b, Direction direction, Block[,] gameArea)
        {
            //compute new Location
            int xNewPos = (int)b.X;
            int yNewPos = (int)b.Y;

            switch(direction)
            {
                case Direction.Down:
                    yNewPos++;
                    break;
                case Direction.Left:
                    xNewPos--;
                    break;
                case Direction.Right:
                    xNewPos++;
                    break;
            }

            // move block
            gameArea[xNewPos, yNewPos] = b;
            gameArea[(int)b.X, (int)b.Y] = null;

            // update block location
            b.X = xNewPos;
            b.Y = yNewPos;
        }

        private static void RevertMove(List<Block> movedBlocks, Direction direction, Block[,] gameArea)
        {
            foreach (Block b in movedBlocks)
            {
                gameArea[(int)b.X, (int)b.Y] = null;
                switch(direction)
                {
                    case Direction.Down: b.Y--; break;
                    case Direction.Left: b.X++; break;
                    case Direction.Right: b.X--; break;
                }
                b.Falling = false;
            }
            foreach (Block b in movedBlocks)
            {
                gameArea[(int)b.X, (int)b.Y] = b;
            }
        }

        #endregion


        #region FallingProcess
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
            foreach (Block b in fellBlocks)
            {
                gameArea[(int)b.X, (int)b.Y] = b;
            }
        } 
        #endregion
    }
}
