using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockT : TetraBlock
    {
        public TetraBlockT() : base(new bool[2, 3] {
                { true,  true, true },
                { false, true, false } })
        { }
    }
}
