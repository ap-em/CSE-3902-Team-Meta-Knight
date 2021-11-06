using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CRemoveObject : ICommand
    {

        IGameObject go;
        public CRemoveObject(IGameObject go, Rectangle rectangle)
        {
            this.go = go;
        }
        public void Execute()
        {
            GameObjectManager.Instance.RemoveFromObjectList(go);
        }
    }
}
