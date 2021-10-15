using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
    class CCyclePreviousBlock : ICommand
    {
        private Game0 game;
        public CCyclePreviousBlock(Game0 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.block.PrevSprite();
        }
    }
}
