using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands
{
    class CPlayerJumpEnemy : ICommand
    {
        private Mario player;
        public CPlayerJumpEnemy(IMario mario, Rectangle rect)
        {
            player = (Mario)mario;
        }
        public void Execute()
        {
            /*
             * This is so incredibly janky if it works.
             */
            player.currentState = new RightFacingStaticMario(player);
            player.Jump();


        }
    }
}
