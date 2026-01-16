using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace monogame_ski_lucas_culhaci.Core.Facade
{
    public static class InputFacade
    {

        private static KeyboardState CurrentState { get; set; }
        private static KeyboardState PreviousState { get; set; }

        public static void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        public static bool IsAnyKeyDown(IEnumerable<Keys> keys) => keys.Any(IsKeyDown);

        public static bool IsKeyDown(Keys key) => CurrentState.IsKeyDown(key);

        public static bool WasKeyJustPressed(Keys key)
            => CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);

    }
}
