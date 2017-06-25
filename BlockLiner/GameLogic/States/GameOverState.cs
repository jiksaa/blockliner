using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BlockLiner.GameLogic.States
{
    class GameOverState : BlockLinerState
    {
        public override Type StateType
        {
            get
            {
                return Type.GameOver;
            }
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            throw new NotImplementedException();
        }
    }
}
