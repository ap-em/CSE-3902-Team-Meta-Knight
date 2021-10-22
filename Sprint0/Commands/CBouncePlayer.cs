using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CBouncePlayer:ICommand
    {
        public string direction;
        public Mario player;
        public CBouncePlayer(string directionRef, Mario playerRef)
        {
            direction = directionRef;
            player = playerRef;

        }

        public void Execute()
        {
            player.Bounce(direction);
        }
    }
}
