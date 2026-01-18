using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_ski_lucas_culhaci.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.Object.Obstacles
{
    public class Snowman(Texture2D texture, Vector2 position) : Sprite(texture, position)
    {
        public int Direction { get; set; } = 1; // 1 = Rechts, -1 is Lnks
    
    }
}
