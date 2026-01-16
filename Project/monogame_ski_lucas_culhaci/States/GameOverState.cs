using Microsoft.Xna.Framework;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.States.Base;

namespace monogame_ski_lucas_culhaci.States
{
    public class GameOverState(Game1 context) : State(context)
    {
        public override void Draw(GameTime gameTime)
        {

            // TODO: Make a new SpirteBatchExtension that makes the game over look similar to what is in the pdf
            Context._spriteBatch.DrawStringInCenter
                (
                Context._graphics,
                ContentService.Instance.GetSpriteFont("game-font"),
                "Game Over\n" +
                "Enter om teruygf naar het menu te gaan"
                );
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
