using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLiner.GameLogic.Blocks;
using Microsoft.Xna.Framework.Graphics;

namespace BlockLiner.Graphics.Mono
{
    class MonoRenderer : IBlockLinerRenderer
    {
        private GraphicsDevice _graphicDevice;
        private SpriteBatch _spritebatch;

        public MonoRenderer(GraphicsDevice graphics)
        {
            _graphicDevice = graphics;
            _spritebatch = new SpriteBatch(_graphicDevice);
        }


        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void DrawBlock(Block b)
        {
            throw new NotImplementedException();
        }

        public void End()
        {
            throw new NotImplementedException();
        }
    }
}
