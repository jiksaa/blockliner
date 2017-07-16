using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using BlockLiner.GameLogic.Blocks;
using BlockLiner.GameLogic.Exceptions;
using System;

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

        private const double _KEYPOLLINGTIME = 0.05;

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
                _inputElapsedTime = 0;
                HandleInput(gamestate);
            }

            if (_fallingTime > _seconds)
            {
                _fallingTime = 0;
                return FallingProcess(gamestate);
            }
            return this;
        }

        #region InputHandling
        private void HandleInput(IBlockLiner gamestate)
        {
            try
            {
                KeyboardState kbs = Keyboard.GetState();
                if (kbs.IsKeyDown(Keys.Left))
                {
                    Move(Direction.Left, gamestate);
                }
                if (kbs.IsKeyDown(Keys.Right))
                {
                    Move(Direction.Right, gamestate);
                }
                if (kbs.IsKeyDown(Keys.Down))
                {
                    Move(Direction.Down, gamestate);
                }
                if (kbs.IsKeyDown(Keys.Up))
                {
                    Rotate(gamestate);
                }
            }
            catch (UnplacableBlockException)
            {
                
            }
        }

        private static void Rotate(IBlockLiner gamestate)
        {
            // retrieve fallingBlocks
            List<Block> fallingBlocks = GetFallingBlocks(gamestate);


            // extract (x.y) min and max position
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            foreach(Block b in fallingBlocks)
            {
                minX = (b.X < minX) ? (int)b.X : minX;
                minY = (b.Y < minY) ? (int)b.Y : minY;
                maxX = (b.X > maxX) ? (int)b.X : maxX;
                maxY = (b.Y > maxY) ? (int)b.Y : maxY;
            }

            // create rotation pattern

            // should be refactored !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Block[,] rotationMatrix = new Block[4,4];

            // declaring (x,y) mapping function
            Func<int, int> XMapping = (int realx) => { return realx - minX; };
            Func<int, int> YMapping = (int realy) => { return realy - minY; };

            // foreach falling blocks put block inside the pattern
            // according to mapping functions
            foreach (Block b in fallingBlocks)
            {
                int xPatternPos = XMapping((int)b.X);
                int yPatternPos = YMapping((int)b.Y);

                rotationMatrix[xPatternPos, yPatternPos] = b;
            }
        }

        #endregion

        #region Common

        private static List<Block> GetFallingBlocks(IBlockLiner gamestate)
        {
            List<Block> fallingBlocks = new List<Block>();

            int xLength = gamestate.GameArea.GetLength(0);
            int yLength = gamestate.GameArea.GetLength(1);

            foreach(Block b in gamestate.GameArea)
            {
                if (b != null && b.Falling)
                    fallingBlocks.Add(b);
            }

            return fallingBlocks;
        }

        private static void Move(Direction direction, IBlockLiner gamestate)
        {
            List<Block> movableBlock = new List<Block>();

            // get gameArea dimension
            int xLength = gamestate.GameArea.GetLength(0);
            int yLength = gamestate.GameArea.GetLength(1);

            // iterate through gameArea for falling blocks that going
            // to be affected by movement
            for (int y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLength; x++)
                {
                    Block b = gamestate.GameArea[x, y];
                    if (b != null && b.Falling)
                    {
                        gamestate.GameArea[x, y] = null;
                        MoveBlock(b, direction);
                        movableBlock.Add(b);
                    }
                }
            }

            if (movableBlock.Count == 0)
                throw new UnplacableBlockException();

            // if any error during iteration, revert block position
            if (AreAbleToMove(movableBlock, direction, gamestate.GameArea))
            {
                foreach (Block b in movableBlock)
                {
                    gamestate.GameArea[(int)b.X, (int)b.Y] = b;
                }
            }
            else
            {
                RevertMove(movableBlock, direction, gamestate.GameArea);
                throw new UnplacableBlockException();
            }
        }

        private static bool AreAbleToMove(List<Block> movedBlocks, Direction direction, Block[,] gameArea)
        {
            bool validMove = true;

            foreach (Block b in movedBlocks)
            {
                int maxX = gameArea.GetLength(0);
                int maxY = gameArea.GetLength(1);

                int xToCheck = (int)b.X;
                int yToCheck = (int)b.Y;

                if(!(xToCheck >= 0 && xToCheck < maxX && yToCheck < maxY && gameArea[xToCheck, yToCheck] == null))
                {
                    validMove = false;
                    break;
                }
            }
            return validMove;
        }

        private static void MoveBlock(Block b, Direction direction)
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
            // update block location
            b.X = xNewPos;
            b.Y = yNewPos;
        }

        private static void RevertMove(List<Block> movedBlocks, Direction direction, Block[,] gameArea)
        {
            foreach (Block b in movedBlocks)
            {

                // revert Block position
                switch(direction)
                {
                    case Direction.Down:
                        b.Y--;
                        b.Falling = false;
                        break;
                    case Direction.Left: b.X++; break;
                    case Direction.Right: b.X--; break;
                }
                gameArea[(int)b.X, (int)b.Y] = b;
            }
        }

        #endregion

        #region FallingProcess
        private BlockLinerState FallingProcess(IBlockLiner gamestate)
        {
            try
            {
                Move(Direction.Down, gamestate);
            }
            catch (UnplacableBlockException)
            {
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
