using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerRightBounce : ICommand
    {
        public string direction;
        public IMario mario;
        public Rectangle rectangle;
        public CPlayerRightBounce(Mario playerRef, Rectangle rectangle)
        {
            mario = playerRef;
            this.rectangle = rectangle;
        }

        public void Execute()
        {
            mario.RightBounce(rectangle);
        }
    }
}
