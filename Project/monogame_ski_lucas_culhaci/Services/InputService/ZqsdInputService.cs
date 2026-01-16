using Microsoft.Xna.Framework.Input;
using monogame_ski_lucas_culhaci.Core.Facade;
using monogame_ski_lucas_culhaci.Interface;
using System;

namespace monogame_ski_lucas_culhaci.Services.InputService
{
    public class ZqsdInputService : IPlayerMovementInputService
    {
        public bool GoDown()
        {
            if (InputFacade.IsKeyDown(Keys.S))
                return true;
            return false;
        }

        public bool GoLeft()
        {
            if (InputFacade.IsKeyDown(Keys.Q))
                return true;
            return false;
        }

        public bool GoRight()
        {
            if (InputFacade.IsKeyDown(Keys.D))
                return true;
            return false;
        }

        public bool GoUp()
        {
            if (InputFacade.IsKeyDown(Keys.Z))
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
