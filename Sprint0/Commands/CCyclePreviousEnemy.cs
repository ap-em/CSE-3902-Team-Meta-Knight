using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCyclePreviousEnemy : ICommand
    {
        private Game0 gameHere;
        public CCyclePreviousEnemy(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.PrevEnemy();
        }
    }
}
