using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic.Blocks
{
    class TetraBlockO : TetraBlock
    {
        public TetraBlockO() : base( new bool[2,2] { 
                { true, true},
                { true, true} }) { }
    }
}
