using BlockLiner.GameLogic;
using BlockLiner.GameLogic.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.Graphics
{
    class RenderingSystem : IRenderingSystem
    {

        private IBlockLinerRenderer _renderer;
        private IBlockLiner _gamestate;

        public RenderingSystem(IBlockLinerRenderer renderer, IBlockLiner gamestate)
        {
            _renderer = renderer;
            _gamestate = gamestate;
        }

        void IRenderingSystem.Render()
        {
            // extracting working data : gamearea and gamearea size
            Block[,] gameArea = _gamestate.GameArea;
            uint xSize = (uint)gameArea.GetLength(0);
            uint ySize = (uint)gameArea.GetLength(1);

            _renderer.Begin();

            // draw gameboarder
            _renderer.DrawBorder();

            // draw blocks
            foreach (Block b in gameArea)
            {
                // avoid drawing null Block
                if(b != null)
                {
                    _renderer.DrawBlock(b);
                }
            }

            _renderer.End();
        }
    }
}
