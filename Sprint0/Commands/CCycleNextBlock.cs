using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
