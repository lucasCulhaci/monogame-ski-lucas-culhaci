using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Core.Base;
using monogame_ski_lucas_culhaci.Enums;
using monogame_ski_lucas_culhaci.Object.Obstacles;
using monogame_ski_lucas_culhaci.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.Services.Manager
{
    public class ObstacleManager
    {
        private double _rockTimer;
        private double _treeTrunkTimer;
        private double _snowmanTimer;

        public List<Sprite> ActiveObstacles { get; } = new();
        private readonly ObstacleFactory _factory = new();

        public ObstacleManager()
        {
            ResetTimers();
        }

        public void ResetTimers()
        {
            _rockTimer = Random.Shared.Next(Game1.ROCK_MIN_SPAWNRATE_INMS, Game1.ROCK_MAX_SPAWNRATE_INMS);
            _treeTrunkTimer = Random.Shared.Next(Game1.TREETRUNK_MIN_SPAWNRATE_INMS, Game1.TREETRUNK_MAX_SPAWNRATE_INMS);
            _snowmanTimer = Random.Shared.Next(Game1.SNOWMAN_MIN_SPAWNRATE_INMS, Game1.SNOWMAN_MAX_SPAWNRATE_INMS);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obstacle in ActiveObstacles)
            {
                obstacle.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            int direction = 1; // 1 is right, -1 is left

            HandleSpawning(elapsedTime);

            for (int i = ActiveObstacles.Count - 1; i >= 0; i--)
            {
               var obstacle = ActiveObstacles[i];
               obstacle.ChangeYPosition(-Game1.OBSTACLE_VERTICAL_STEP);

                if (obstacle is Snowman snowman)
                {
                    if (snowman.Position.X + snowman.Texture.Width >= 720) // Naar links
                        snowman.Direction = -1;
                    else if (snowman.Position.X <= 0) // Naar rechts
                        snowman.Direction = 1;

                    obstacle.ChangeXPosition(Game1.OBSTACLE_VERTICAL_STEP * snowman.Direction);
                }


                if (obstacle.Position.Y < -100)
                    ActiveObstacles.RemoveAt(i);
            }
        }

        private void HandleSpawning(double elapsedTime)
        {
            // ROCK
            _rockTimer -= elapsedTime;
            if (_rockTimer < 0)
            {
                Spawn(ObstacleType.Rock);
                _rockTimer = Random.Shared.Next(Game1.ROCK_MIN_SPAWNRATE_INMS, Game1.ROCK_MAX_SPAWNRATE_INMS);
            }

            // TREE TRUNK
            _treeTrunkTimer -= elapsedTime;
            if (_treeTrunkTimer < 0)
            {
                Spawn(ObstacleType.TreeTrunk);
                _treeTrunkTimer = Random.Shared.Next(Game1.TREETRUNK_MIN_SPAWNRATE_INMS, Game1.TREETRUNK_MAX_SPAWNRATE_INMS);
            }

            // SNOWMAN
            _snowmanTimer -= elapsedTime;
            if (_snowmanTimer < 0)
            {
                Spawn(ObstacleType.Snowman);
                _snowmanTimer = Random.Shared.Next(Game1.SNOWMAN_MIN_SPAWNRATE_INMS, Game1.SNOWMAN_MAX_SPAWNRATE_INMS);
            }
        }

        private void Spawn(ObstacleType type)
        {
            // TODO: Don't forget to replace these values

            int xPosition = Random.Shared.Next(0, 720);
            Vector2 position = new Vector2(xPosition, 1080);

            ActiveObstacles.Add(_factory.CreateObstacle(type, position));
    
        }


    }
}
