using Microsoft.Xna.Framework;

namespace monogame_ski_lucas_culhaci.States.Base
{
    public abstract class State(Game1 context)
    {
        protected Game1 Context { get; } = context;

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }
}
