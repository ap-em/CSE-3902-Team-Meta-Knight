using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactory;

namespace Sprint0.Commands
{
    class CAnimatedMovingSprite : ICommand
    {

        private static Game0 gameHere;

        public CAnimatedMovingSprite(Game0 game)
        {
            gameHere = game;
        }
        
        public void Execute()
        {
                gameHere.sprite = SpriteFactory.Instance.GetSprite("RightLink");
        }
    }
}
