using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCycleNextBlock : ICommand
    {
        private Game0 gameHere;
        public CCycleNextBlock(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.block.NextBlock();
        }
    }
}
