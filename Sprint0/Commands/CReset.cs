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
            GameObjectManager.Instance.RemoveAllObjects();
            Game0.Instance.CreatePlayer();
            LevelFactory.Instance.CreateLevel(LevelFactory.Instance.currentLevel);
        }
    }
}
