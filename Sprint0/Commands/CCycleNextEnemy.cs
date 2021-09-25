using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCycleNextEnemy : ICommand
    {
        /*OG Code written by Owen Huston, modifed by Owen Tishenkel to call enemy rather than game*/
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
