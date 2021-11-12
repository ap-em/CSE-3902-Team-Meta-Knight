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
        private Mario mario;
        public CKillEnemy(Enemy enemyReference, Mario mario, Rectangle rec)
        {
            enemy = enemyReference;
        }
        public void Execute()
        {
            enemy.InstantDeath();
        }
    }
}
