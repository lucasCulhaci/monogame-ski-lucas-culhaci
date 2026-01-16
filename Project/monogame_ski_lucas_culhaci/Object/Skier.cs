using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Interface;
using monogame_ski_lucas_culhaci.Object.Models;
using monogame_ski_lucas_culhaci.Object.Sprites;

namespace monogame_ski_lucas_culhaci.Object
{
    public class Skier
    {

        public PlayerModel Model { get; private set; }
        public PlayerSprite Sprite { get; private set; }

        private IPlayerMovementInputService _inputService;

        public Skier(Texture2D texture, Vector2 position, IPlayerMovementInputService inputService)
        {
            Model = new PlayerModel();
            Sprite = new PlayerSprite(texture, position);
            _inputService = inputService;
        }

        public void Update(GameTime gameTime)
        {
            if (Model.isAlive)
                Sprite.Update(gameTime, _inputService);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Model.isAlive)
                Sprite.Draw(spriteBatch);
        }
    }
}
