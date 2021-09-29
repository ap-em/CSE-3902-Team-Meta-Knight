using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyRight : ICommand
    {
        private IEnemy enemy;
        public CMoveEnemyRight(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.MoveRight();
        }
    }
}
