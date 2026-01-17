using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame_ski_lucas_culhaci.Core.Facade;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.States.Base;

namespace monogame_ski_lucas_culhaci.States
{
    public class PauseState : State
    {
        private readonly State _originState;
        private readonly Texture2D _overlayTexture;

        public PauseState(Game1 context, State originState) : base(context)
        {
            _originState = originState;

            _overlayTexture = new Texture2D(Context.GraphicsDevice, 1, 1);
            _overlayTexture.SetData(new[] { Color.White });
        }

        public override void Draw(GameTime gameTime)
        {
            _originState.Draw(gameTime);

            Context._spriteBatch.Draw(
                _overlayTexture,
                new Rectangle(0, 0, Context._graphics.PreferredBackBufferWidth, Context._graphics.PreferredBackBufferHeight),
                Color.Black * 0.6f
            );

            Context._spriteBatch.DrawStringInCenter
                (
                Context._graphics,
                ContentService.Instance.GetSpriteFont("game-font"),
                "Gepauzeerd.\n" +
                "Druk op 'P' om door te gaan."
                );
        }

        public override void Update(GameTime gameTime)
        {
            if (InputFacade.WasKeyJustPressed(Keys.P))
                Context.ChangeState(_originState);
        }
    }
}