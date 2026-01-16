using Microsoft.Xna.Framework;
using monogame_ski_lucas_culhaci.Extensions;
using monogame_ski_lucas_culhaci.Services;
using monogame_ski_lucas_culhaci.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.States
{
    public class PauseState(Game1 context) : State(context)
    {
        public override void Draw(GameTime gameTime)
        {
            Context._spriteBatch.DrawStringInCenter
                (
                Context._graphics,
                ContentService.Instance.GetSpriteFont("game-font"),
                "Dit werkt!"
                );
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
