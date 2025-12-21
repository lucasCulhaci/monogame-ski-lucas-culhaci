using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Ski_Lucas_Culhaci.Extensions;

namespace Monogame_Ski_Lucas_Culhaci.Core.Base
{
    public abstract class Sprite(Texture2D texture, Vector2 position)
    {

        public Texture2D Texture { get; } = texture;

        public Vector2 Position { get; private set; } = position;

        public int Width => Texture.Width;

        public int Height => Texture.Height;

        public Rectangle GetBounds() => new Rectangle((int)Position.X,(int)Position.Y, Width, Height);

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position);
        }

        internal void ChangeXPosition(float xPositionChange)
        {
            Position = Position with { X = Position.X + xPositionChange }; 
        }

        internal void ChangeYPosition(float yPositionChange)
        {
            Position = Position with { Y = Position.Y + yPositionChange };
        }

    }
}
