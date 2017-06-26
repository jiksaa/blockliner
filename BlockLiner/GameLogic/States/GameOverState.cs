using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
            KeyboardState kb = Keyboard.GetState();
            if(kb.IsKeyDown(Keys.Y)) {
                gamestate.Reset();
                return gamestate.GetStateInstance(Type.Init);
            }
            if(kb.IsKeyDown(Keys.N))
            {
                gamestate.Exit();
            }
            return this;
        }
    }
}
