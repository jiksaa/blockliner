using BlockLiner.GameLogic.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.Graphics
{
    interface IBlockLinerRenderer
    {
        void Begin();
        void DrawBlock(Block b);
        void DrawBorder();
        void End();
    }
}
