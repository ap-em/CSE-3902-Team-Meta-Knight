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
        IMario mario;
        IDynamicBlock block;

        public CBreakBlock(IDynamicBlock block, IMario mario, Rectangle rectangle)
        {
            this.mario = mario;
            this.block = block;
        }
        public void Execute()
        {

            if (mario.IsJumping())
            {
                block.BreakBlock(mario);
            }
                
            
            
        }
    }
}
