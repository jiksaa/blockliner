using Microsoft.Xna.Framework;

namespace BlockLiner.GameLogic.States
{
    abstract class BlockLinerState
    {
        private Type stateType;
        public abstract Type StateType { get; }

        /// <summary>
        /// Update gamelogic for the given delta time
        /// </summary>
        /// <param name="delta">Current delta time</param>
        /// <returns>New state of the current gamelogic</returns>
        public abstract BlockLinerState Update(IBlockLiner gamestate, GameTime delta);

        public enum Type
        {
            Init,
            Falling,
            Checking,
            NewBlock,
            GameOver
        }
    }
}
