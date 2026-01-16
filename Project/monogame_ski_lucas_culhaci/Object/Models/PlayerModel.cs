using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.Object.Models
{
    public class PlayerModel
    {

        public bool isAlive = false;

        public PlayerModel()
        {
            isAlive = true;
        }

        public void Die() => isAlive = false;
    }
}
