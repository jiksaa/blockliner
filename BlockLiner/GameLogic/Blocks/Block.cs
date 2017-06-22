using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class Block
    {
        private float _x;
        private float _y;
        private bool _falling;

        public float X
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

        public float Y
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

            set
            {
                _falling = value;
            }
        }

        public Block(float x, float y, bool falling)
        {
            X = x;
            Y = y;
            Falling = falling;
        }

        public Block(float x, float y) : this(x,y,false) { }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")" + Falling;
        }

    }
}
