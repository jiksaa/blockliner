using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockI : TetraBlock
    {
        public TetraBlockI() : base(new bool[1, 4] { { true, true, true, true } }) { }
    }
}
