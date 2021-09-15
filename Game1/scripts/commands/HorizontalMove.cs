using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class HorizontalMove : ICommand
    {
        private Game1 myGame;
        public HorizontalMove(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.mario = new WalkSprite(myGame.marioSprite);
            myGame.characterController.SetVerticalSpeed(0);

            //if facing left move left
            if (myGame.characterController.GetHorizontalDirection() > 0) myGame.characterController.SetHorizontalSpeed(1);
            else myGame.characterController.SetHorizontalSpeed(-1);

        }
    }
}
