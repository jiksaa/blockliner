using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class Block
    {
        private uint _x;
        private uint _y;
        private bool _falling;

        public uint X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public uint Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public bool Falling
        {
            get
            {
                return _falling;
            }

            private set
            {
                _falling = value;
            }
        }

        public Block(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
