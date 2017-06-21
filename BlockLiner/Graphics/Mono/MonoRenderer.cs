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

        private Vector2[] _borderpPositionVectors;
        private Vector2[,] _gameAreaPositonVectors;

        public MonoRenderer(GraphicsDevice graphics, uint width, uint height)
        {
            _witdh = width;
            _height = height;
            _graphicDevice = graphics;
            _spritebatch = new SpriteBatch(_graphicDevice);
            
            // instantiate Vector2 arrays

            // borderPosition is 2 vertical line of _height blocks in addition
            // to the horizontal border of _width blocks
            _borderpPositionVectors = new Vector2[_height * 2 + _witdh];
            // replicate the size of the gameArea
            _gameAreaPositonVectors = new Vector2[_witdh, _height];

            InitializeTextures();

            BuildBorderPositionVector();
            BuildGameAreaPositionVector();
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
            int xOffset = _BLOCKSIZE;
            int yOffset = _BLOCKSIZE;

            //vline vectors construction
            int arrayIndex = 0;
            for (int i = 0; i < _height; i++)
            {
                // compute actual x y position
                // offset + block line number * blocksize
                int currentY = yOffset + i * _BLOCKSIZE;
                int currentX = xOffset;

                // left vline border
                _borderpPositionVectors[arrayIndex] = new Vector2(currentX, currentY);
                arrayIndex++;

                // right vline border
                currentX += _BLOCKSIZE + ((int)_witdh + 1) * _BLOCKSIZE;
                _borderpPositionVectors[arrayIndex] = new Vector2(currentX, currentY);
                arrayIndex++;
            }

            //hline vectors construction
            int hlineY = yOffset + (int)_height * _BLOCKSIZE;
            for (int i = 0; i < _witdh; i++)
            {
                int hlineX = xOffset + (i + 1) * _BLOCKSIZE;
                _borderpPositionVectors[arrayIndex] = new Vector2(hlineX, hlineY);
                arrayIndex++;
            }

        }

        private void BuildGameAreaPositionVector()
        {
            int xOffset = _BLOCKSIZE * 2;
            int yOffset = _BLOCKSIZE;

            for (int x = 0; x < _witdh; x++)
            {
                int currentX = xOffset + x * _BLOCKSIZE;
                for (int y = 0; y < _height; y++)
                {
                    int currentY = yOffset + y * _BLOCKSIZE;
                    _gameAreaPositonVectors[x, y] = new Vector2(currentX, currentY);
                }
            }
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
