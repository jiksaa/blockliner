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
        private int _WIDTH;
        private int _HEIGHT;

        private Block[,] _gameArea;
        private BlockLinerState _state;

        public TestingBlockLiner(int width, int height)
        {
            _WIDTH = width;
            _HEIGHT = height;

            _gameArea = new Block[_WIDTH, _HEIGHT];
            _state = new FallingState(0.5);


            _gameArea[3, 0] = new Block(3, 0, true);
            _gameArea[3, 1] = new Block(3, 1, true);
            _gameArea[3, 2] = new Block(3, 2, true);
            _gameArea[2, 0] = new Block(2, 0, true);

            _gameArea[2, 5] = new Block(2, 5);
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
            _state = _state.Update(this,delta);
        }

        public TetraBlock PopNextTetraBlock()
        {
            throw new NotImplementedException();
        }
    }
}
