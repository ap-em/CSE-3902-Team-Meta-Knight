using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCycleNextEnemy : ICommand
    {
        private Game0 gameHere;
        public CCycleNextEnemy(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.NextEnemy();
        }
    }
}
