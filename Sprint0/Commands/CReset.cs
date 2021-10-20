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
        /*Declaration for each command needed to reset every aspect of sprint 2*/
        ICommand blockReset;
        ICommand enemyReset;
        ICommand itemReset;
        ICommand playerReset;
        /*CReset relys on the fact that the constructors for each Entity class put them in the correct spot at startup*/
        public CReset(IMario mario)
        {
            /*
            blockReset = new CResetBlock(game);
            enemyReset = new CResetEnemy(game);
            itemReset = new CResetItem(game);
            playerReset = new CResetPlayer(game);
            */
            
        }

        public void Execute()
        {
            /*
            playerReset.Execute();
            blockReset.Execute();
            enemyReset.Execute();
            itemReset.Execute();
            */
        }
    }
}
