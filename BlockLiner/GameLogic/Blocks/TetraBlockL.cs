using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockL : TetraBlock
    {
        public TetraBlockL() : base(new bool[3,2] {
                { true,  true },
                { true,  false },
                { true,  false } })
        { }
    }
}
