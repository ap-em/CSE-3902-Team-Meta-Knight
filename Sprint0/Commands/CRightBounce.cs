using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CRightBounce : ICommand
    {
        public string direction;
        public ICollidable go;
        public Rectangle rectangle;
        public CRightBounce(ICollidable go, Rectangle rectangle)
        {
            this.go = go;
            this.rectangle = rectangle;
        }

        public void Execute()
        {
            go.RightBounce(rectangle);
        }
    }
}
