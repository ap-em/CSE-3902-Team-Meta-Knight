using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CZeroEnemyXVelocity : ICommand
    {
        private Game0 gameHere;
        public CZeroEnemyXVelocity(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetXVelocity(0);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
