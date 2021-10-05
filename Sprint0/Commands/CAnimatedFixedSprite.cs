using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactory;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Commands
{
    class CAnimatedFixedSprite : ICommand
    {

        private static Game0 gameHere;

        public CAnimatedFixedSprite(Game0 game)
        {
            gameHere = game;
        }
        
        public void Execute()
        {
            gameHere.sprite = SpriteFactory.Instance.GetSprite("RightLink"); // This is the fixed sprite. Poorly named.
        }
    }
}
