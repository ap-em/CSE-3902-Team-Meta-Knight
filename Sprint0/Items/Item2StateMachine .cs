using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Items
{
    class Item2StateMachine : IItemStateMachine
    {
        Item item;
        private ISprite sprite;
        public Item2StateMachine(Item item)
        {
            this.item = item;
            
        }

        public void NextItem()
        {
            item.SetStateMachine(new Item3StateMachine(item));
        }

        public void PrevItem()
        {
            item.SetStateMachine(new Item1StateMachine(item));
        }

        public void SetSprite()
        {
            // sprite = SpriteFactory.Instance.CreateNewSprite("Item2");
            Debug.WriteLine("Item2");
        }

        public void Update()
        {
            Debug.WriteLine("Nothing to update for Item 1 State");
        }
    }
}
