using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerDownBounce : ICommand
    {
        public string direction;
        public IMario mario;
        public CPlayerDownBounce(IMario playerRef)
        {
            mario = playerRef;
        }

        public void Execute()
        {
            mario.DownBounce();
        }
    }
}
