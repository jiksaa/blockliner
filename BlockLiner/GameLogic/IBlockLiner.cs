using BlockLiner.GameLogic.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic
{
    interface IBlockLiner
    {
        Block[,] GameArea
        {
            get;
        }

        void Update(GameTime delta);
    }
}
