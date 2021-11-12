using Sprint0.Enemies;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands
{
    class CKillEnemy : ICommand
    {
        private Enemy enemy;
        IKillBox killBox;
        public CKillEnemy(Enemy enemyReference, IKillBox killBox, Rectangle rec)
        {
            enemy = enemyReference;
            this.killBox = killBox;
        }
        public void Execute()
        {
            killBox.Kill(enemy);
        }
    }
}
