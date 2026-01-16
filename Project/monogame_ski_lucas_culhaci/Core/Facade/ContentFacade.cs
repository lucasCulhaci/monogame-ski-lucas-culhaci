using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace monogame_ski_lucas_culhaci.Core.Facade
{
    public static class ContentFacade
    {

        public static IEnumerable<Texture2D> LoadTextures2D(Game game, string[] names)
            => names?.Select(name => LoadTexture2D(game, name));

        public static Texture2D LoadTexture2D(Game game, string name)
            => game.Content.Load<Texture2D>(name);

        public static IEnumerable<SpriteFont> LoadSpriteFonts(Game game, string[] names)
            => names?.Select(name => LoadSpriteFont(game, name));

        public static SpriteFont LoadSpriteFont(Game game, string name)
            => game.Content.Load<SpriteFont>(name);
    }
}
