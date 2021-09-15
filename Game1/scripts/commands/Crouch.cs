using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Crouch : ICommand
    {
        private Game1 myGame;
        public Crouch(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.mario = new CrouchSprite(myGame.marioSprite);
            myGame.characterController.SetHorizontalSpeed(0);
            myGame.characterController.SetVerticalSpeed(0);
            
        }
    }
}
