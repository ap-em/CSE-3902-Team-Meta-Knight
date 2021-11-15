using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.HUD;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    class CTogglePauseGame : ICommand
    {
        IMario mario;
        public CTogglePauseGame(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            HUDManager.Instance.GetHUD((IGameObject)mario).TogglePause();
        }
    }
}
