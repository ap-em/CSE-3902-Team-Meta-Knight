using Sprint0.Enemies;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands
{
    class CGetKicked : ICommand
    {
        private Enemy enemy;
        private IMario mario;
        private Rectangle rec;
        public CGetKicked(Enemy enemy, IMario mario, Rectangle rec)
        {
            this.enemy = enemy;
            this.rec = rec;

        }
        public void Execute()
        {
            enemy.GetKicked(rec);
        }
    }
}
