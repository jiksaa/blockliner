using BlockLiner.GameLogic;
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
            throw new NotImplementedException();
        }
    }
}
