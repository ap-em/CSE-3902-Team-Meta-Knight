using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CDownBounce : ICommand
    {
        public string direction;
        public IBounce go;
        public Rectangle rectangle;

        public CDownBounce(IBounce go, ICollidable collided, Rectangle rectangle)
        {
            this.go = go;
            this.rectangle = rectangle;
        }

        public void Execute()
        {
            go.DownBounce(rectangle);
        }
    }
}
