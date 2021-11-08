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

        public CReset(IMario mario)
        {
            
        }

        public void Execute()
        {
            Level.Instance.Reset();
            GameObjectManager.Instance.RemoveAllObjects();
            Game0.Instance.CreatePlayer();
            Game0.Instance.soundInfo.StopLoopedSound("OverworldTheme");
            Game0.Instance.soundInfo.PlaySound("OverworldTheme",true);
            

            
        }
    }
}
