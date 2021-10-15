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
    class CCycleNextBlock : ICommand
    {
        private Game0 game;
        public CCycleNextBlock(Game0 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.block.NextBlock();
        }
    }
}
