using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CUseItemBlock : ICommand
    {
        IBlock Block;
        public CUseItemBlock(IBlock block, Rectangle rectangle)
        {
        Block = block;
        }
        public void Execute()
        {
            Debug.WriteLine("Debug test hit bottom of item block");
            
        }
    }
}
