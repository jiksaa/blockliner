using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BlockLiner.GameLogic.Blocks;

namespace BlockLiner.GameLogic.States
{
    class CheckingState : BlockLinerState
    {
        public override Type StateType
        {
            get
            {
                return Type.Checking;
            }
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            return ValidateLines(gamestate);
        }

        private BlockLinerState ValidateLines(IBlockLiner gamestate)
        {
            List<int> toRemove = new List<int>();
            Block[,] matrix = gamestate.GameArea;
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);


            for (int y = 0; y < height; y++)
            {
                if (IsFullLine(matrix, y))
                {
                    toRemove.Add(y);
                }   
            }

            if(toRemove.Count != 0)
            {
                RemoveLines(matrix, toRemove);
            }

            return gamestate.GetStateInstance(Type.NewBlock);
        }

        private bool IsFullLine(Block[,] matrix, int y)
        {
            int width = matrix.GetLength(0);
            for (int x = 0; x < width; x++)
            {
                if(matrix[x,y] == null)
                {
                    return false;
                }
            }
            return true;
        }

        private void RemoveLines(Block[,] matrix, List<int> toRemove)
        {
            foreach (int row in toRemove)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    matrix[x, row] = null;
                }
                FallBlockAbove(matrix, row);
            }
        }

        private void FallBlockAbove(Block[,] matrix, int y)
        {
            int height = matrix.GetLength(1);
            for (int it = y-1; it >= 0 ; it--)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    // get block
                    Block b = matrix[x, it];
                    if (b == null) continue;

                    // fall block by 1 and update matrix
                    b.Y += 1;
                    matrix[x, (int)b.Y] = b;

                    //remove from previous position
                    matrix[x, it] = null;
                }
            }
        }
    }
}
