using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCyclePreviousBlock : ICommand
    {
        private IBlock block;
        public CCyclePreviousBlock(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.PrevBlock();
        }
    }
}
