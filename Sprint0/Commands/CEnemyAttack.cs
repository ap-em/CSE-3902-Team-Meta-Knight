using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CEnemyAttack : ICommand
    {
        private Game0 gameHere;
        public CEnemyAttack(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.FireProjectile();
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
