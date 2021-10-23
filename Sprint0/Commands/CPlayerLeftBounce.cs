using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerLeftBounce : ICommand
    {
        public string direction;
        public IMario mario;
        Rectangle rectangle;
        public CPlayerLeftBounce(IMario playerRef, Rectangle rectangle)
        {
            mario = playerRef;
            this.rectangle = rectangle;
        }

        public void Execute()
        {
            mario.LeftBounce(rectangle);
        }
    }
}
