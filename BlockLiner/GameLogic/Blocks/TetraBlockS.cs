using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockS : TetraBlock
    {
        public TetraBlockS() : base(new bool[3, 2] {
                { false, true },
                { true, true },
                { true, false }
        }) { }
    }
}
