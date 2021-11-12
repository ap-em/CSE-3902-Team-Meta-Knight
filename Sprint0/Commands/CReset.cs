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
            //reset score and time
            HUDManager.Instance.GetHUD((IGameObject)mario).Reset();
            GameObjectManager.Instance.RemoveAllObjects();
            Game0.Instance.soundInfo.StopLoopedSound("OverworldTheme");

            //only reset level if game isnt over
            if (HUDManager.Instance.GetHUD((IGameObject)mario).GetLives() > 0)
            {
                Game0.Instance.soundInfo.PlaySound("OverworldTheme", true);
                LevelFactory.Instance.CreateLevel(HUDManager.Instance.GetHUD((IGameObject)mario).GetLevel());
            }
        }
    }
}
