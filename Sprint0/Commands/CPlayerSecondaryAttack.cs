using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CPlayerSecondaryAttack : ICommand
    {
        ILink secondaryAttack;
        public CPlayerSecondaryAttack(ILink secondaryAttack)
        {
            this.secondaryAttack = secondaryAttack;
        }

        public void Execute()
        {
            secondaryAttack.Execute();
        }
    }
}
