using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockZ : TetraBlock
    {
        public TetraBlockZ() : base(new bool[3, 2] {
                { true,  false },
                { true,  true },
                { false, true } })
        { }
    }
}
