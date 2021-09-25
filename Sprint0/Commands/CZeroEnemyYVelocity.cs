using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CZeroEnemyYVelocity : ICommand
    {
        private Game0 gameHere;
        public CZeroEnemyYVelocity(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetYVelocity(0);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
