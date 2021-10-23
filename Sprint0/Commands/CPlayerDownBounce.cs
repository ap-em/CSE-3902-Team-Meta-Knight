using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerDownBounce : ICommand
    {
        public string direction;
        public IMario mario;
        public Rectangle rectangle;

        public CPlayerDownBounce(IMario playerRef, Rectangle rectangle)
        {
            mario = playerRef;
            this.rectangle = rectangle;
        }

        public void Execute()
        {
            mario.DownBounce(rectangle);
        }
    }
}
