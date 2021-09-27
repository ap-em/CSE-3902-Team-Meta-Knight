using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCycleNextEnemy : ICommand
    {
        private IEnemy enemy;
        public CCycleNextEnemy(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.NextEnemy();
        }
    }
}
