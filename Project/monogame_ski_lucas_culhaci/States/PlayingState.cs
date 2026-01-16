using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Interface;
using monogame_ski_lucas_culhaci.Object;
using monogame_ski_lucas_culhaci.Object.Obstacles;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.Services.InputService;
using monogame_ski_lucas_culhaci.Services.Manager;
using monogame_ski_lucas_culhaci.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.States
{
    public class PlayingState : State
    {
        private List<Skier> _skiers;
        private bool _spawnEnemies;
        private ObstacleManager _obstacleManager;
        
            Game1 context;

        public PlayingState(Game1 context, int amountOfSkiers, bool hasEnemies, bool multipleControls) : base(context)
        {
            this.context = context;
            _skiers = new();
            _spawnEnemies = hasEnemies;
            _obstacleManager = new ObstacleManager();

            SetupSkiers(amountOfSkiers, multipleControls);
        }

        public override void Draw(GameTime gameTime)
        {

            if(_spawnEnemies)
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
            foreach (var skier in _skiers)
                skier.Update(gameTime);

            if(_spawnEnemies)
            {
                _obstacleManager.Update(gameTime);
            }

            CheckCollisions();

            if (_skiers.All(s => !s.Model.isAlive))
                Context.ChangeState(new PauseState(context));
        }


        private void SetupSkiers(int amountOfSkiers, bool multipleControls)
        {

            Texture2D skierTexture = ContentService.Instance.GetTexture("skiier");

            for(int i = 0; i < amountOfSkiers; i++)
            {
                // TODO: Wijzig dit naar iets dat iets deftiger werkt
                Vector2 startPosition = new Vector2(200 + (i * 60), 100);

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
                            skier.Sprite.ChangeYPosition(-80);
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
