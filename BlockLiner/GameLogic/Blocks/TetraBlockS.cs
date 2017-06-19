using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockS : TetraBlock
    {
        public TetraBlockS() : base(new bool[2, 3] {
                { false, true, true },
                { true,  true, false } })
        { }
    }
}
