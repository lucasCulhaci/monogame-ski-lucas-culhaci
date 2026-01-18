using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Core.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.Services
{
    public class ContentService
    {

        private static ContentService _instance = null;
        public static ContentService Instance => _instance ?? throw new Exception("Initialize was not called");

        private readonly Dictionary<string, Texture2D> _textures;
        private readonly Dictionary<string, SpriteFont> _fonts;

        private readonly IEnumerable<string> _textureFileNames = new[] { "rock", "skiier", "snowman", "tree-bottom", "background" };
        private readonly IEnumerable<string> _fontFileNames = new[] { "game-font" };


        private ContentService(Game game)
        {
            _textures = new();
            _fonts = new();

            // Load Textures
            foreach (var item in _textureFileNames)
                _textures.Add(item, ContentFacade.LoadTexture2D(game, item));

            // Load Fonts
            foreach (var item in _fontFileNames)
                _fonts.Add(item, ContentFacade.LoadSpriteFont(game, item));
        }

        public static void Initialize(Game game)
        {
            _instance = new ContentService(game);
        }

        public Texture2D GetTexture(string name) => _textures[name];

        public SpriteFont GetSpriteFont(string name) => _fonts[name];

    }
}
