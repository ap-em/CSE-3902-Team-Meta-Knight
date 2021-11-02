using Sprint0.Enemies;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CDamageEnemy : ICommand
    {
        private Enemy enemy;
        public CDamageEnemy(Enemy enemyRefernce)
        {
            enemy = enemyRefernce;
        }
        public void Execute()
        {
            enemy.TakeDamage();
        }
    }
}
