using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerRightBounce : ICommand
    {
        public string direction;
        public IMario mario;
        public CPlayerRightBounce(Mario playerRef)
        {
            mario = playerRef;
        }

        public void Execute()
        {
            mario.RightBounce();
        }
    }
}
