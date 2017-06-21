using BlockLiner.GameLogic.Blocks;
using BlockLiner.GameLogic.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLiner.GameLogic
{
    interface IBlockLiner
    {
        Block[,] GameArea { get; }
        TetraBlock NextTetraBlock { get; }
        BlockLinerState.Type CurrentState { get; }

        void Update(GameTime delta);
        BlockLinerState GetStateInstance(BlockLinerState.Type stateType);
        TetraBlock PopNextTetraBlock();
    }
}
