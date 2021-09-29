using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CZeroEnemyXVelocity : ICommand
    {
        private IEnemy enemy;
        public CZeroEnemyXVelocity(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.SetXVelocity(0);
        }
    }
}
