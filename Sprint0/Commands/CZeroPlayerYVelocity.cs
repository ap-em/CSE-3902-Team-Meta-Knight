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
        ILink link;
        public CZeroPlayerYVelocity(ILink link)
        {
            this.link = link;
        }
        public void Execute()
        {
            link.StopMovingVertical();
        }
    }
}
