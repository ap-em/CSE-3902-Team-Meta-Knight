using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyLeft : ICommand
    {
         private Game0 gameHere;
        public CMoveEnemyLeft(Game0 game)
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
