using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    class CTogglePauseGame : ICommand
    {
        public CTogglePauseGame(IMario mario)
        {

        }
        public void Execute()
        {
            Game0.Instance.TogglePause();
        }
    }
}
