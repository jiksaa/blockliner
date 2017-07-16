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
        private static BlockLinerState _fallingState = new FallingState(0.2);
        private static BlockLinerState _checkingState = new CheckingState();
        private static BlockLinerState _gameoverState = new GameOverState();

        private Block[,] _gameArea;
        private TetraBlock[] _tetraArray;
        private BlockLinerState _currentState;
        private Game _gameInstance;

        private Random _randomGenerator;

        public BlockLinerLogic(uint width, uint height, Game gameInstance)
        {
            _randomGenerator = new Random();
            _gameInstance = gameInstance;
            _gameArea = new Block[width, height];

            // instantiate tetrablock pattern
            _tetraArray = new TetraBlock[]
            {
                new TetraBlockO(),
                new TetraBlockL(),
                new TetraBlockI(),
                new TetraBlockJ(),
                new TetraBlockS(),
                new TetraBlockT(),
                new TetraBlockZ()
            };

            ShuffleTetraBlock();

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
                return _tetraArray[0];
            }
        }

        public TetraBlock PopNextTetraBlock()
        {
            TetraBlock next = _tetraArray[0];
            ShuffleTetraBlock();
            return next;
        }

        private void ShuffleTetraBlock()
        {
            
            int arraySize = _tetraArray.Length;
            // foreach tetrablock of the list generate random swaping
            while(arraySize > 1)
            {
                int newPos = _randomGenerator.Next(arraySize--);
                TetraBlock tb = _tetraArray[arraySize];
                _tetraArray[arraySize] = _tetraArray[newPos];
                _tetraArray[newPos] = tb;
            }
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

        public void Exit()
        {
            _gameInstance.Exit();
        }

        public void Reset()
        {
            // retrieve actual game area size
            int width = _gameArea.GetLength(0);
            int height = _gameArea.GetLength(1);

            // replace game area by a fresh instance
            _gameArea = null;
            _gameArea = new Block[width, height];

            // call garbage collector to ensure previous game blocks to be freed
            GC.Collect();
        }
    }
}
