using System;
using Microsoft.Xna.Framework;

namespace BlockLiner.GameLogic.States
{
    class NewBlockState : BlockLinerState
    {
        public NewBlockState()
        {
            StateType = Type.NewBlock;
        }

        public override BlockLinerState Update(IBlockLiner gamestate, GameTime delta)
        {
            throw new NotImplementedException();
        }
    }
}
