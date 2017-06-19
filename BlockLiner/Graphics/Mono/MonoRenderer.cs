using System;
using BlockLiner.GameLogic.Blocks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BlockLiner.Graphics.Mono
{
    class MonoRenderer : IBlockLinerRenderer
    {
        private const int _BLOCKSIZE = 16;

        private uint _witdh;
        private uint _height;
        private GraphicsDevice _graphicDevice;
        private SpriteBatch _spritebatch;

        private Texture2D _borderTexture;
        private Texture2D _blockTexture;

        public MonoRenderer(GraphicsDevice graphics, uint width, uint height)
        {
            _witdh = width;
            _height = height;
            _graphicDevice = graphics;
            _spritebatch = new SpriteBatch(_graphicDevice);

            InitializeTextures();

        }

        private void InitializeTextures()
        {
            _borderTexture = new Texture2D(_graphicDevice, _BLOCKSIZE, _BLOCKSIZE);
            _blockTexture = new Texture2D(_graphicDevice, _BLOCKSIZE, _BLOCKSIZE);

            int arraySize = _BLOCKSIZE * _BLOCKSIZE;

            Color[] borderColor = new Color[arraySize];
            Color[] blockColor = new Color[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                borderColor[i] = Color.White;
                blockColor[i] = Color.CornflowerBlue;

            }
            _borderTexture.SetData(borderColor);
            _blockTexture.SetData(blockColor);
        }

        private void BuildBorderPositionVector()
        {

        }

        public void Begin()
        {
            _spritebatch.Begin();
        }

        public void DrawBlock(Block b)
        {
            throw new NotImplementedException();
        }

        public void DrawBorder()
        {
            throw new NotImplementedException();
        }

        public void End()
        {
            _spritebatch.End();
        }
    }
}
