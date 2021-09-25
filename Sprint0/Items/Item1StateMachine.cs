using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void PrevItem()
        {
            throw new NotImplementedException();
        }

        public void SetSprite()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
