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
        private IBlock block;
        public CCycleNextBlock(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.NextBlock();
        }
    }
}
