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
    class BlockLinerLogic : IBlockLiner
    {
        private static BlockLinerState _initState = new InitState();
        private static BlockLinerState _newBlockState = new NewBlockState();
        private static BlockLinerState _fallingState = new FallingState(0.5);
        private static BlockLinerState _checkingState = new CheckingState();
        private static BlockLinerState _gameoverState = new GameOverState();

        private Block[,] _gameArea;
        private List<TetraBlock> _tetraList;
        private BlockLinerState _currentState;

        private int _tetraListIndex;

        public BlockLinerLogic(uint width, uint height)
        {
            _gameArea = new Block[width, height];

            // instantiate tetrablock pattern
            _tetraList = new List<TetraBlock>()
            {
                new TetraBlockO(),
                new TetraBlockL(),
                new TetraBlockI(),
                new TetraBlockJ(),
                new TetraBlockS(),
                new TetraBlockT(),
                new TetraBlockZ()
            };

            _tetraListIndex = 0;

            // set initialization state
            _currentState = _initState;

        }

        public BlockLinerState.Type CurrentState
        {
            get
            {
                return _currentState.StateType;
            }
        }

        public Block[,] GameArea
        {
            get
            {
                return _gameArea;
            }

            set
            {
                _gameArea = value;
            }
        }

        public TetraBlock NextTetraBlock
        {
            get
            {
                return _tetraList[_tetraListIndex];
            }
        }

        public TetraBlock PopNextTetraBlock()
        {
            TetraBlock next = _tetraList[_tetraListIndex];
            _tetraListIndex++;
            _tetraListIndex %= _tetraList.Count;
            // TODO: shuffle list after one round
            return next;
        }

        public BlockLinerState GetStateInstance(BlockLinerState.Type stateType)
        {
            // TODO: may be refactored to an array of BlockLinerState and search the good one
            switch (stateType)
            {
                case BlockLinerState.Type.Init: return _initState;
                case BlockLinerState.Type.NewBlock: return _newBlockState;
                case BlockLinerState.Type.Falling: return _fallingState;
                case BlockLinerState.Type.Checking: return _checkingState;
                case BlockLinerState.Type.GameOver: return _gameoverState;
            }
            throw new ArgumentException("BlockLinerState is not supported");
        }

        public void Update(GameTime delta)
        {
            _currentState = _currentState.Update(this, delta);
        }
    }
}
