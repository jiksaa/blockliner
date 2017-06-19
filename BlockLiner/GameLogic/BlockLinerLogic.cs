using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLiner.GameLogic.Blocks;
using Microsoft.Xna.Framework;

namespace BlockLiner.GameLogic
{
    class BlockLinerLogic : IBlockLiner
    {
        private Block[,] _gameArea;
        private List<TetraBlock> _tetraList;

        public BlockLinerLogic(uint width, uint height)
        {
            _gameArea = new Block[width, height];

            // instantiate tetrablock pattern
            _tetraList = new List<TetraBlock>()
            {
                new TetraBlockI(),
                new TetraBlockJ(),
                new TetraBlockL(),
                new TetraBlockO(),
                new TetraBlockS(),
                new TetraBlockT(),
                new TetraBlockZ()
            };

        }

        public Block[,] GameArea
        {
            get
            {
                return _gameArea;
            }
        }

        public void Update(GameTime delta)
        {
            // add state pattern logic and action
            throw new NotImplementedException();
        }
    }
}
