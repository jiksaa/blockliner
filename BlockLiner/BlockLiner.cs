using BlockLiner.GameLogic;
using BlockLiner.Graphics;
using BlockLiner.Graphics.Mono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockLiner
{
    public class BlockLiner : Game
    {

        public static uint ResolutionWidth = 600;
        public static uint ResolutionHeight = 800;
        public static uint BoardWidth = 12;
        public static uint BoardHeight = 26;

        private IBlockLiner _gamelogic;

        private IBlockLinerRenderer _renderer;
        private IRenderingSystem _rendering;

        private GraphicsDeviceManager _graphics;

        public BlockLiner()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = (int) ResolutionHeight;
            _graphics.PreferredBackBufferWidth = (int) ResolutionWidth;
        }

        protected override void Initialize()
        {
            // gamelogic initialization
            //_gamelogic = new BlockLinerLogic(BoardWidth, BoardHeight);
            _gamelogic = new TestingBlockLiner();

            // graphics initialization
            _renderer = new MonoRenderer(GraphicsDevice, BoardWidth, BoardHeight);
            _rendering = new RenderingSystem(_renderer, _gamelogic);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.Window.Title = "FPS: " + 1 / gameTime.ElapsedGameTime.TotalSeconds;

            _rendering.Render();

            base.Draw(gameTime);
        }
    }
}
