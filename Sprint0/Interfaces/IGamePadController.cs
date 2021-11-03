using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces
{
    public interface IGamePadController
    {
        void Update();
        void RegisterCommand(Buttons button, ICommand command);
        void RegisterHoldableKey(Buttons button, ICommand command);
        void RegisterReleasableKey(Buttons button, ICommand command);
        void ClearController();
    }
}
