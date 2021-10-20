using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
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
    /*Owen Tishenkel 2021 CSE 3902*/
    class CDamagePlayer : ICommand
    {
        IMario mario;
        public CDamagePlayer(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.TakeDamage();
        }
    }
}
