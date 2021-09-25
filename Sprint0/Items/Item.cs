using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Items
{
    class Item : IItems
    {
        Game0 game;
        IItemStateMachine stateMachine;
        ISprite sprite;
        public Item(Game0 game)
        {
            this.game = game;
            stateMachine = new Item1StateMachine(this);
        }

        public void NextItem()
        {
            throw new NotImplementedException();
        }

        public void PrevItem()
        {
            throw new NotImplementedException();
        }

        public void SetStateMachineSprite()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }

        
    }
}
