using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CUseItem : ICommand
    {
        // TODO THIS DOES NOT WORK 
        IItem Item;
        public CUseItem(IItem item, Rectangle rect)
        {
            Item = item;
            
        }
        public void Execute()
        {
            Debug.WriteLine("attempting use item: " + Item.GetItemName());
            String item = Item.GetItemName();
            
            if (item == "Mushroom")
            {
                //Mario.MushroomPower();
            }
            else if (item == "Fireflower")
            {

            }
            else if (item == "Star")
            {

            }
 
        }
    }
}
