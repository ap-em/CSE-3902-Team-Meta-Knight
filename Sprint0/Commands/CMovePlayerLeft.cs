using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    class CMovePlayerLeft : ICommand
    {
         private Game0 gameHere;
        public CMovePlayerLeft(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetDirection("left");
            gameHere.enemy.SetXVelocity(-1);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
