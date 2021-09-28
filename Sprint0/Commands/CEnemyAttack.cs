using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CEnemyAttack : ICommand
    {
        private IEnemy enemy;
        public CEnemyAttack(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.FireProjectile();
            enemy.SetStateMachineSprite();
        }
    }
}
