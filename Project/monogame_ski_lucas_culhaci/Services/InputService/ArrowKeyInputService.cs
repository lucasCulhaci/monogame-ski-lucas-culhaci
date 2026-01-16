using Microsoft.Xna.Framework.Input;
using monogame_ski_lucas_culhaci.Core.Facade;
using monogame_ski_lucas_culhaci.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.Services.InputService
{
    public class ArrowKeyInputService : IPlayerMovementInputService
    {
        public bool GoDown()
        {
            if (InputFacade.IsKeyDown(Keys.Down))
                return true;
            return false;
        }

        public bool GoLeft()
        {
            if (InputFacade.IsKeyDown(Keys.Left))
                return true;
            return false;
        }

        public bool GoRight()
        {
            if (InputFacade.IsKeyDown(Keys.Right))
                return true;
            return false;
        }

        public bool GoUp()
        {
            if (InputFacade.IsKeyDown(Keys.Up))
                return true;
            return false;
        }

        public bool Pause()
        {
            if (InputFacade.IsKeyDown(Keys.P))
                return true;
            return false;
        }
    }
}
