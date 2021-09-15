using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class VerticalMove : ICommand
    {
        private Game1 myGame;
        public VerticalMove(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
             myGame.mario = new JumpSprite(myGame.marioSprite);
             myGame.characterController.SetHorizontalSpeed(0);
             myGame.characterController.SetVerticalSpeed(1);
        }
    }
}
