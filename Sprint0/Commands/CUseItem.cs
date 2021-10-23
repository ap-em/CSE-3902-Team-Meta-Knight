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

        IMario Mario;
        IItem Item;
        public CUseItem(IItem item, Rectangle rect)
        {
            //Mario = mario;
            Mario = Game0.Instance.mario;
            Item = item;
            
        }
        public void Execute()
        {
            Debug.WriteLine("attempting use item: " + Item.GetItemName());
            String item = Item.GetItemName();
            
            if (item == "Mushroom")
            {
                Mario.MushroomPower();
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
