using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Timers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CResetGame : ICommand
    {
        IMario mario;

        public CResetGame(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            //reset score, time, lives
            HUDManager.Instance.GetHUD((IGameObject)mario).ResetGame();
            GameObjectManager.Instance.RemoveAllObjects();
            TimerManager.Instance.RemoveAllTimers();
            LevelFactory.Instance.CreateLevel(1);
        }
    }
}
