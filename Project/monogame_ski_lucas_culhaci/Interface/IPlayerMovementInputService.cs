using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_ski_lucas_culhaci.Interface
{
    public interface IPlayerMovementInputService
    {
        bool GoRight();
        bool GoLeft();
        bool GoUp();
        bool GoDown();
    }
}
