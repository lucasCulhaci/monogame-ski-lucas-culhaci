using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using monogame_ski_lucas_culhaci.Core;
using monogame_ski_lucas_culhaci.Core.Facade;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.States.Base;

namespace monogame_ski_lucas_culhaci.States
{
    public class MenuState(Game1 context) : State(context)
    {

        private bool _isInitialized = false;

        public override void Draw(GameTime gameTime)
        {
            Context._spriteBatch.DrawStringInCenter
                (
                Context._graphics,
                ContentService.Instance.GetSpriteFont("game-font"),
                "Druk 1: 3 Skiiers\n\n" +
                "Druk 2: Vijanden /1 skiier\n\n" +
                "Druk 3: Vijanden /3 skiier\n\n" +
                "Druk 4: Vijanden /2 spelers"
                );
        }

        public override void Update(GameTime gameTime)
        {
            // 3 Skiiers
            if (InputFacade.WasKeyJustPressed(Keys.D1))
                StartGame(3, false, false);

            //  Vijanden /1 skiier
            if (InputFacade.WasKeyJustPressed(Keys.D2))
                StartGame(1, true, false);

            // Vijanden /3 skiier
            if (InputFacade.WasKeyJustPressed(Keys.D3))
                StartGame(3, true, false);

            // Vijanden /2 spelers"
            if (InputFacade.WasKeyJustPressed(Keys.D4))
                StartGame(2, true, true);
            
            
        }

        private void StartGame(int amountOfSkiers, bool hasEnemies, bool multipleControls)
            => Context.ChangeState(new PlayingState(Context, amountOfSkiers, hasEnemies, multipleControls));
    }
}
