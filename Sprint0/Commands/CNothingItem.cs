using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands
{
    class CNothingItem : ICommand
    {

        IGameObject Item;
        public CNothingItem(IGameObject item, Rectangle rectangle)
        {
            Item = item;
        }
        public void Execute()
        {
            GameObjectManager.Instance.RemoveFromObjectList(Item);
        }
    }
}
