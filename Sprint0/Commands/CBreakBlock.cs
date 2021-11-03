using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CBreakBlock : ICommand
    {

        IBlock Block;
        IMario Mario;     
        public CBreakBlock(IBlock block, IMario mario)
        {
            Mario = mario;
            Block = block;
        }
        public void Execute()
        {
            Block.BreakBlock(Mario);
        }
    }
}
