using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCyclePreviousEnemy : ICommand
    {
        private IEnemy enemy;
        public CCyclePreviousEnemy(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.PrevEnemy();
        }
    }
}
