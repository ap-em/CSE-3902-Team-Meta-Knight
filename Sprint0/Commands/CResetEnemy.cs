using Sprint0.Controllers;
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
    class CResetEnemy : ICommand
    {

        /*gameHere provides access to game for the purposes of reseting many of the things that it contains*/
        Game0 gameHere;
        /*CResetEnemy is a subcommand for CReset which resets Enemy Location and sprite to the intial value*/
        public CResetEnemy(Game0 game)
        {
            gameHere = game;
        }

        public void Execute()
        {
            gameHere.enemy = new Enemy();
        }
    }
}
