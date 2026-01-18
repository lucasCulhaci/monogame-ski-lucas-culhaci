using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace monogame_ski_lucas_culhaci.Extensions
{
    public static class SpriteBatchExtensions
    {

        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float scale)
            => spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

        public static void DrawStringInCenter(this SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteFont spriteFont, string text)
        {
            var position = CalculateCenterPosition(graphics, spriteFont, text);
            spriteBatch.DrawString(spriteFont, text, position, Color.Black);
        }

        public static Vector2 CalculateCenterPosition(GraphicsDeviceManager graphics, SpriteFont spriteFont, string text)
        {
            var textSize = spriteFont.MeasureString(text);

            return new Vector2
                (
                    (graphics.PreferredBackBufferWidth - textSize.X) * .5F,
                    (graphics.PreferredBackBufferHeight - textSize.Y) * .5F
                );
        }

    }
}
