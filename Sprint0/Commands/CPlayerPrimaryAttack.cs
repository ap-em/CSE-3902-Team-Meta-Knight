using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    class CPlayerPrimaryAttack : ICommand
    {
        ILink primaryAttack;
        public CPlayerPrimaryAttack(ILink primaryAttack)
        {
            this.primaryAttack = primaryAttack;
        }

        public void Execute()
        {
            primaryAttack.Execute();
        }
    }
}
