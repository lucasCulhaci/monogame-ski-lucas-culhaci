using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Core.Base;
using monogame_ski_lucas_culhaci.Interface;


namespace monogame_ski_lucas_culhaci.Object.Sprites
{
    public class PlayerSprite(Texture2D texture, Vector2 position) : Sprite(texture, position)
    {

        public void Update(GameTime gameTime, IPlayerMovementInputService inputService)
        {

            if (inputService.GoRight())
                ChangeXPosition(Game1.PLAYER_STEP);

            if (inputService.GoLeft())
                ChangeXPosition(-Game1.PLAYER_STEP);

            if (inputService.GoUp())
                ChangeYPosition(-Game1.PLAYER_STEP);

            if (inputService.GoDown())
                ChangeYPosition(Game1.PLAYER_STEP);

        }

    }
}
