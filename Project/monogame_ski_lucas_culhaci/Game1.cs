using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame_ski_lucas_culhaci.Core.Facade;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Object;
using monogame_ski_lucas_culhaci.Object.Sprites;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.States;
using monogame_ski_lucas_culhaci.States.Base;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace monogame_ski_lucas_culhaci
{
    public class Game1 : Game
    {
        #region CONSTANTS

        #region PLAYER
        // [DEFAULT STEP] > The player IS NOT MOVING (does not press zqsd or arrow keys), vertical movement is slowed
        internal const int PLAYER_STEP_SLOWED = 1;
        // [PLAYING STEP] > The player MOVES (ZQSD or ARROW KEYS)
        internal const int PLAYER_STEP = 3;
        #endregion

        #region BACKGROUND
        // [DEFAULT STEP] > The player IS NOT MOVING (does not press zqsd or arrow keys), vertical movement is slowed
        internal const int BACKGROUND_STEP_SLOWED = 1;
        // [PLAYING STEP] > The player MOVES (ZQSD or ARROW KEYS)
        internal const int BACKGROUND_STEP = 3;
        #endregion

        #region OBSTACLES
        // [DEFAULT STEP] > The player IS NOT MOVING (does not press zqsd or arrow keys), vertical movement is slowed
        internal const int OBSTACLE_VERTICAL_STEP_SLOWED = 1;
        // [PLAYING STEP] > The player MOVES (ZQSD or ARROW KEYS)
        internal const int OBSTACLE_VERTICAL_STEP = 3;

        // [DEFAULT MOVEMENT VELOCITY] > ROCK
        internal const int ROCK_KNOCKBACK = 2;
        // [DEFAULT MOVEMENT VELOCITY] > SNOWMAN
        internal const int SNOWMAN_HORIZONTAL_STEP = 5;

        // [SPAWNRATE] > ROCK
        public const int ROCK_MIN_SPAWNRATE_INMS = 500;
        public const int ROCK_MAX_SPAWNRATE_INMS = 2_000;
        // [SPAWNRATE] > TREETRUNK
        public const int TREETRUNK_MIN_SPAWNRATE_INMS = 1_500;
        public const int TREETRUNK_MAX_SPAWNRATE_INMS = 5_000;
        // [SPAWNRATE] > SNOWMAN
        public const int SNOWMAN_MIN_SPAWNRATE_INMS = 3_000;
        public const int SNOWMAN_MAX_SPAWNRATE_INMS = 10_000;
        #endregion

        #endregion

        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch _spriteBatch;

        #region TODO: Move thos whole part to PlayingState.cs
        //internal List<Skier> skiers;

        //internal double _elapsedTimeSinceLastRock;
        //internal double _elapsedTimeSinceLastTreeTrunk;
        //internal double _elapsedTimeSinceLastSnowman;

        //internal List<Vector2> _rockPositions;
        //internal List<Vector2> _treeTrunkPositions;
        //internal List<Vector2> _snowmanPositions;
        //internal List<Vector2> _backgroundPositions;
        #endregion

        private State _currentState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        internal void ChangeState(State newState) => _currentState = newState;

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            ContentService.Initialize(this);

            ChangeState(new MenuState(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputFacade.Update();

            if (InputFacade.WasKeyJustPressed(Keys.Escape))
                Exit();

            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _currentState.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
