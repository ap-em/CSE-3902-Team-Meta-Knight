using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerUpBounce : ICommand
    {
        public string direction;
        public IMario mario;
        public CPlayerUpBounce(IMario playerRef)
        {
            mario = playerRef;
        }

        public void Execute()
        {
            mario.UpBounce();
        }
    }
}
