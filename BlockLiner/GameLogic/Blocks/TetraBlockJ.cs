using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockJ : TetraBlock
    {
        public TetraBlockJ() : base( new bool[2, 3] { 
                { false, false, false },
                { true,  true,  true } }) { }
    }
}
