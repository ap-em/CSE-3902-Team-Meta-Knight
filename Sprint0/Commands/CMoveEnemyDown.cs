using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyDown : ICommand
    {
        private static Game0 gameHere;
        public CMoveEnemyDown(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetDirection("down");
            gameHere.enemy.SetYVelocity(1);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
