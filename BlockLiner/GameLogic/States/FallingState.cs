using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BlockLiner.GameLogic.States
{
    class FallingState : BlockLinerState
    {
        public FallingState()
        {
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            // falling logic
            return this;
        }
    }
}
