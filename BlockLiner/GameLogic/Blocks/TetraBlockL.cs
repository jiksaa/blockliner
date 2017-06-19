using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockL : TetraBlock
    {
        public TetraBlockL() : base(new bool[2,3] {
                { false, false, true },
                { true,  true,  true } })
        { }
    }
}
