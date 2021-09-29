using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyUp : ICommand
    {
        private IEnemy enemy;
        public CMoveEnemyUp(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.MoveUp();
        }
    }
}
