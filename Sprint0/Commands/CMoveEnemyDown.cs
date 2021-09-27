using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyDown : ICommand
    {
        private IEnemy enemy;
        public CMoveEnemyDown(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.SetDirection("down");
            enemy.SetYVelocity(1);
            enemy.SetStateMachineSprite();
        }
    }
}
