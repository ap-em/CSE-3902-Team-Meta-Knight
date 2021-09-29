using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyLeft : ICommand
    {
        private IEnemy enemy;
        public CMoveEnemyLeft(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.MoveLeft();
        }
    }
}
