using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame_ski_lucas_culhaci.Core.Facade;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Interface;
using monogame_ski_lucas_culhaci.Object;
using monogame_ski_lucas_culhaci.Object.Obstacles;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.Services.InputService;
using monogame_ski_lucas_culhaci.Services.Manager;
using monogame_ski_lucas_culhaci.States.Base;
using System.Collections.Generic;
using System.Linq;


namespace monogame_ski_lucas_culhaci.States
{
    public class PlayingState : State
    {
        private List<Skier> _skiers;
        private bool _spawnEnemies;
        private ObstacleManager _obstacleManager;

        private Texture2D _backgroundTexture;
        private List<Vector2> _backgroundPositions;
        
        Game1 context;

        public PlayingState(Game1 context, int amountOfSkiers, bool hasEnemies, bool multipleControls) : base(context)
        {
            this.context = context;
            _skiers = new();
            _spawnEnemies = hasEnemies;
            _obstacleManager = new ObstacleManager();
            _backgroundTexture = ContentService.Instance.GetTexture("background");
            _backgroundPositions = new List<Vector2> { new Vector2(0, 0), new Vector2(0, _backgroundTexture.Height) };

            SetupSkiers(amountOfSkiers, multipleControls);
        }

        public override void Draw(GameTime gameTime)
        {

            foreach (var position in _backgroundPositions)
            {
                Context._spriteBatch.Draw(_backgroundTexture, position, 1);
            }

            if (_spawnEnemies)
            {
                _obstacleManager.Draw(Context._spriteBatch);
            }

            foreach (var skier in _skiers)
            {
                skier.Draw(Context._spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {

            var movementKeys = new List<Keys> {
                Keys.Z, Keys.Q, Keys.S, Keys.D,
                Keys.Up, Keys.Down, Keys.Left, Keys.Right
            };

            // Background
            float scrollSpeed = Game1.BACKGROUND_STEP;

            if (InputFacade.WasKeyJustPressed(Keys.P))
                Context.ChangeState(new PauseState(context, this));

            // If the user is playing and wants to get back to the menu, he can press 'M'
            if (InputFacade.WasKeyJustPressed(Keys.M))
                Context.ChangeState(new MenuState(context));

            if (InputFacade.IsAnyKeyDown(movementKeys))
                scrollSpeed = Game1.BACKGROUND_STEP;
            else
                scrollSpeed = Game1.BACKGROUND_STEP_SLOWED;

            for (int i = 0; i < _backgroundPositions.Count; i++)
            {
                // Move the background upwards
                _backgroundPositions[i] = _backgroundPositions[i] with { Y = _backgroundPositions[i].Y - scrollSpeed };

                if (_backgroundPositions[i].Y <= -_backgroundTexture.Height)
                {
                    // Calculate the other index, for example: if the current image is 0, then the other image has the index of 1
                    int otherIndex = (i == 0) ? 1 : 0;

                    _backgroundPositions[i] = _backgroundPositions[i] with { Y = _backgroundPositions[otherIndex].Y + _backgroundTexture.Height - 10 };
                }
            }

            // Skiers
            foreach (var skier in _skiers)
                skier.Update(gameTime);
            
            // Enemies
            if(_spawnEnemies)
            {
                _obstacleManager.Update(gameTime);
            }

            CheckCollisions();

            if (_skiers.All(s => !s.Model.isAlive))
                Context.ChangeState(new GameOverState(context));
        }

        private void SetupSkiers(int amountOfSkiers, bool multipleControls)
        {

            Texture2D skierTexture = ContentService.Instance.GetTexture("skiier");

            for(int i = 0; i < amountOfSkiers; i++)
            {
                // X POSITION: Screenwidth / 2 + PlayerSpriteWidth + (index * 60 -> used for the next skieer)
                Vector2 startPosition = new Vector2((Game1.SCREEN_WIDTH) / 2 + 70 + i * 60, 100);

                IPlayerMovementInputService inputService;

                if (multipleControls)
                {
                    if (i == 0)
                        inputService = new ZqsdInputService();
                    else
                        inputService = new ArrowKeyInputService();
                }
                else
                {
                    inputService = new ZqsdInputService();
                }

                _skiers.Add(new Skier(skierTexture, startPosition, inputService));
            }

            if (_skiers.Count >= 1)
            {
                foreach (var skier in _skiers)
                {
                    skier.Sprite.Position = skier.Sprite.Position with { X = skier.Sprite.Position.X - 160 };
                }
            }
        }

        private void CheckCollisions()
        {
            foreach(var skier in _skiers)
            {
                if (!skier.Model.isAlive) continue;

                foreach(var obstacle in _obstacleManager.ActiveObstacles)
                {
                    if (skier.Sprite.GetBounds().Intersects(obstacle.GetBounds()))
                    {
                        if (obstacle is Rock)
                        {
                            skier.Sprite.ChangeYPosition(-200);
                        }
                        else
                        {
                            skier.Model.Die();
                        }
                    }
                }

            }
        }

    }
}
