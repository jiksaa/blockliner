using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLiner.GameLogic.Blocks;
using BlockLiner.GameLogic.States;
using Microsoft.Xna.Framework;

namespace BlockLiner.GameLogic
{
    class TestingBlockLiner : IBlockLiner
    {
        private const int _WIDTH = 12;
        private const int _HEIGHT = 28;

        private Block[,] _gameArea;
        private BlockLinerState _state;

        public TestingBlockLiner()
        {
            _gameArea = new Block[_WIDTH, _HEIGHT];
            _state = new FallingState(2);

            _gameArea[3, 0] = new Block(3, 0);
            _gameArea[4, 0] = new Block(4, 0);
            _gameArea[4, 1] = new Block(4, 1);
            _gameArea[5, 1] = new Block(5, 1);
        }

        public BlockLinerState.Type CurrentState
        {
            get
            {
                return _state.StateType;
            }
        }

        public Block[,] GameArea
        {
            get
            {
                return _gameArea;
            }
        }

        public TetraBlock NextTetraBlock
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BlockLinerState GetStateInstance(BlockLinerState.Type stateType)
        {
            return _state;
        }

        public void Update(GameTime delta)
        {
            // do nothing
        }

        public TetraBlock PopNextTetraBlock()
        {
            throw new NotImplementedException();
        }
    }
}
