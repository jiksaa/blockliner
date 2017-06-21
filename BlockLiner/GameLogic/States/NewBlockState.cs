using System;
using Microsoft.Xna.Framework;
using BlockLiner.GameLogic.Blocks;

namespace BlockLiner.GameLogic.States
{
    class NewBlockState : BlockLinerState
    {
        public NewBlockState()
        {
            StateType = Type.NewBlock;
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            // select tetrablock
            TetraBlock next = gamestate.PopNextTetraBlock();
            Block[,] gameArea = gamestate.GameArea;

            // add new tetra to gameArea
            AddTetra(next, gameArea);

            return gamestate.GetStateInstance(Type.Falling);
        }

        public static void AddTetra(TetraBlock tetra, Block[,] matrix)
        {
            int xMiddle = matrix.GetLength(0) / 2;
            int y = 0;

            // checking free space
            bool freeSpace = true;
            bool[,] pattern = tetra.Pattern;
            for (int xt = 0; xt < pattern.GetLength(0); xt++)
            {
                for (int yt = 0; yt < pattern.GetLength(1); yt++)
                {
                    int xMatrix = xMiddle + xt;
                    int yMatrix = y + yt;
                    if (pattern[xt, yt] && matrix[xMatrix, yMatrix] != null)
                    {
                        freeSpace = false;
                        goto End;
                    }
                }
            }
        End:
            if (freeSpace)
            {
                for (int xt = 0; xt < pattern.GetLength(0); xt++)
                {
                    for (int yt = 0; yt < pattern.GetLength(1); yt++)
                    {
                        int xMatrix = xMiddle + xt;
                        int yMatrix = y + yt;
                        matrix[xMatrix, yMatrix] = (pattern[xt, yt]) ? new Block(xMatrix, yMatrix) : null;
                    }
                }
            }
        }

    }
}
