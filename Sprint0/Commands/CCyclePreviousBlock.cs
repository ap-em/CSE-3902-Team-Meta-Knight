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
        private IBlock block;
        public CCyclePreviousBlock(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.PrevSprite();
        }
    }
}
