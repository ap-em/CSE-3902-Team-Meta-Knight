using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class QuitGame : ICommand
    {
        private Game1 myGame;
        public QuitGame(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Exit();
        }
    }
}
