using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockZ : TetraBlock
    {
        public TetraBlockZ() : base(new bool[2, 3] {
                { true,  true, false },
                { false, true,  true } })
        { }
    }
}
