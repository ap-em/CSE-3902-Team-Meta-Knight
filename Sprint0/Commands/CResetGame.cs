using Sprint0.Controllers;
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
            TimerManager.Instance.RemoveAllTimers();

            //reset score and time
            HUDManager.Instance.GetHUD((IGameObject)mario).ResetGame();
            GameObjectManager.Instance.RemoveAllObjects();

            //use cinematic camera till we hit the ground
            CameraManager.Instance.RemoveCamera((IGameObject)mario);
            CameraManager.Instance.CinematicCamera((IGameObject)mario);
            CameraManager.Instance.ResetCamera((IGameObject)mario);

            //lock input till we hit the ground
            IKeyboardController keyboard = PlayerKeyboardManager.Instance.GetKeyboard((IGameObject)mario);
            keyboard.SetLockInput(true);
            LevelFactory.Instance.CreateLevel(LevelFactory.Instance.currentLevel);
        }
    }
}
