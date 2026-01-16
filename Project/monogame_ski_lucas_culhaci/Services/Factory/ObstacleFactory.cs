using Microsoft.Xna.Framework;
using monogame_ski_lucas_culhaci.Core.Base;
using monogame_ski_lucas_culhaci.Enums;
using monogame_ski_lucas_culhaci.Object.Obstacles;


namespace monogame_ski_lucas_culhaci.Services.Factory
{
    public class ObstacleFactory
    {

        public Sprite CreateObstacle(ObstacleType type, Vector2 position)
        {
            var contentService = ContentService.Instance;

            if (type == ObstacleType.Rock)
                return new Rock(contentService.GetTexture("rock"), position);

            if (type == ObstacleType.TreeTrunk)
                return new TreeTrunk(contentService.GetTexture("tree-bottom"), position);

            if (type == ObstacleType.Snowman)
                return new Snowman(contentService.GetTexture("snowman"), position);

            return null;
        }
        
    }
}
