using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    abstract class TetraBlock
    {
        private bool[,] _pattern;

        public bool[,] Pattern
        {
            get
            {
                return _pattern;
            }

            private set
            {
                _pattern = value;
            }
        }

        protected TetraBlock(bool[,] pattern)
        {
            Pattern = pattern;
        }
    }
}
