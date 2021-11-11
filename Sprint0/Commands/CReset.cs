using Sprint0.Controllers;
using Sprint0.HUD;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
    /*Owen Tishenkel 2021 CSE 3902*/
    /*CReset resets every state and location to what it was at startup*/
    class CReset : ICommand
    {
        IMario mario;

        public CReset(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            GameObjectManager.Instance.RemoveAllObjects();
            PlayerKeyboardManager.Instance.RemoveAllKeyboards();
            CameraManager.Instance.cameras.Clear();
            HUDManager.Instance.HUDList.Clear();
            LevelFactory.Instance.CreateLevel(LevelFactory.Instance.currentLevel);
        }
    }
}
