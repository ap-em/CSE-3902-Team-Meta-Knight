using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Items
{
    /*Owen Tishenkel*/
    class ItemStateMachine : IItemStateMachine
    {
        Item item;
        private ISprite sprite;
        private String spriteString;
        public ItemStateMachine(Item item)
        {
            this.item = item;
            
        }

        public void NextItem()
        {
           String itemType = item.getItemType();
            switch(itemType)
            {
                case "HealHeart":
                    item.setItemType("RedRupee");
                    break;
                case "RedRupee":
                    item.setItemType("BlueRupee");
                    break;
                case "BlueRupee":
                    item.setItemType("Bomb");
                    break;
                case "Bomb":
                    item.setItemType("Key");
                    break;
                case "Key":
                    item.setItemType("HealHeart");
                    break;
                default:
                    item.setItemType("HealHeart");
                    break;
            }
            item.setSprite();
        }

        public void PrevItem()
        {
            String itemType = item.getItemType();
            switch (itemType)
            {
                case "HealHeart":
                    item.setItemType("Key");
                    break;
                case "RedRupee":
                    item.setItemType("HealHeart");
                    break;
                case "BlueRupee":
                    item.setItemType("RedRupee");
                    break;
                case "Bomb":
                    item.setItemType("BlueRupee");
                    break;
                case "Key":
                    item.setItemType("Bomb");
                    break;
                default:
                    item.setItemType("HealHeart");
                    break;
            }
            item.setSprite();
        }

        public void Update()
        {
            Debug.WriteLine("Nothing to update for item state");
        }

    }
}
