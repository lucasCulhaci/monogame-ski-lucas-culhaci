using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Extensions;
using System.Reflection.Metadata.Ecma335;

namespace monogame_ski_lucas_culhaci.Core.Base
{
    public abstract class Sprite(Texture2D texture, Vector2 position)
    {

        private const float SCALE = 3; 

        public Texture2D Texture { get; } = texture;

        public Vector2 Position { get; set; } = position;

        public int Width => Texture.Width;

        public int Height => Texture.Height;

        public Rectangle GetBounds() => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(Texture, Position, SCALE);

        public void ChangeXPosition(float xChange) => Position = Position with { X = Position.X + xChange };

        public void ChangeYPosition(float yChange) => Position = Position with { Y = Position.Y + yChange };

    }
}
