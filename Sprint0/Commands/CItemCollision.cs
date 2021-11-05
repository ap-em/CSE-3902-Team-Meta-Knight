using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CItemCollision : ICommand
    {
        // TODO THIS DOES NOT WORK 
        IItem Item;
        IMario mario;
        public CItemCollision(IItem item, IMario mario, Rectangle rect)
        {
            Item = item;
            this.mario = mario;
            
        }
        public void Execute()
        {
            Item.ItemCollision(mario);
        }
    }
}
