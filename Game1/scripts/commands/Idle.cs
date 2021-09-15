using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Idle : ICommand
    {
        private Game1 myGame;
        public Idle(Game1 game)
        {
            myGame = game;

        }
        public void Execute()
        {
           myGame.mario = new IdleSprite(myGame.marioSprite);
           myGame.characterController.SetHorizontalSpeed(0);
           myGame.characterController.SetVerticalSpeed(0);
            
        }
    }
}
