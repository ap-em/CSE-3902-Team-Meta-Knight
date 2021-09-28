using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Items
{
    class Item1StateMachine : IItemStateMachine
    {
        Item item;
        private ISprite sprite;
        public Item1StateMachine(Item item)
        {
            this.item = item;
            
        }

        public void NextItem()
        {
            item.SetStateMachine(new Item2StateMachine(item));
        }

        public void PrevItem()
        {
            item.SetStateMachine(new Item3StateMachine(item));
        }

        public void SetSprite()
        {
           // sprite = SpriteFactory.Instance.CreateNewSprite("Item1");
            Debug.WriteLine("Item1");
            
        }

        public void Update()
        {
            Debug.WriteLine("Nothing to update for Item 1 State");
        }
    }
}
