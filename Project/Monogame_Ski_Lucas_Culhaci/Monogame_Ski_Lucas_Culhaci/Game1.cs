using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Ski_Lucas_Culhaci.Object;
using Monogame_Ski_Lucas_Culhaci.States.Base;
using System.Collections.Generic;

namespace Monogame_Ski_Lucas_Culhaci
{
    public class Game1 : Game
    {

        internal const int PLAYER_STEP = 10;
        internal const int BACKGROUND_STEP = 2;
        internal const int OBSTACLE_STEP = 2;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        internal SpriteFont _font;

        internal int _numberOfRemainingLives;

        internal PlayerSprite Player;

        internal Texture2D _background;
        internal Vector2 _backgroundPosition;

        internal double _elapsedTimeSinceLastBoulderInMs;
        internal double _elapsedTimeSinceLastTreeTrunkInMs;
        internal double _elapsedTimeSinceLastSnowmanInMs;

        internal Texture2D _boulder;
        internal Texture2D _treeTrunk;
        internal Texture2D _snowman;

        internal List<Vector2> _boulderPositions;
        internal List<Vector2> _treeTrunkPositions;
        internal List<Vector2> _snowmanPositions;

        private State _currentState;


        #region Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 1280;
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
