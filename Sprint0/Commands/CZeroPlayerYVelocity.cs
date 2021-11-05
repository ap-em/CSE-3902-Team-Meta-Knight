using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Commands
{
    class CZeroPlayerYVelocity : ICommand
    {
        IMario mario;
        public CZeroPlayerYVelocity(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.StopMovingVertical();
        }
    }
}
