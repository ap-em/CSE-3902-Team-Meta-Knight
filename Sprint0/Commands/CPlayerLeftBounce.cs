using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CPlayerLeftBounce : ICommand
    {
        public string direction;
        public IMario mario;
        public CPlayerLeftBounce(IMario playerRef)
        {
            mario = playerRef;
        }

        public void Execute()
        {
            mario.LeftBounce();
        }
    }
}
