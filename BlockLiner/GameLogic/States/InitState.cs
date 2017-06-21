using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlockLiner.GameLogic.States
{
    class InitState : BlockLinerState
    {
        public InitState()
        {
            StateType = Type.Init;
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Enter))
            {
                System.Diagnostics.Debug.WriteLine("Enter key pressed : starting new game");
                return gamestate.GetStateInstance(Type.NewBlock);
            }
            else
            {
                return this;
            }
        }
    }
}
