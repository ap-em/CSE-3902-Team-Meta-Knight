using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    /*CReset resets every state and location to what it was at startup*/
    class CReset : ICommand
    {
        /*Declaration for each command needed to reset every aspect of sprint 2*/
        ICommand blockReset;
        ICommand enemyReset;
        ICommand itemReset;
        ICommand playerReset;
        /*gameHere provides access to game for the purposes of reseting many of the things that it contains*/
        Game0 gameHere;

        public CReset(Game0 game)
        {
            gameHere = game;
            blockReset = new CResetBlock(game);
            enemyReset = new CResetEnemy(game);
            itemReset = new CResetItem(game);
            playerReset = new CResetPlayer(game);
            
        }

        public void Execute()
        {
            blockReset.Execute();
            enemyReset.Execute();
            itemReset.Execute();
            playerReset.Execute();
        }
    }
}
