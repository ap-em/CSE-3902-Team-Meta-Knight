using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    class Quit:ICommand
    {

        private static Game0 gameHere;
        public Quit(Game0 game)
        {
            gameHere = game;
            
        }
        public void Execute()
        {
            gameHere.Exit();
        }
    }
}
