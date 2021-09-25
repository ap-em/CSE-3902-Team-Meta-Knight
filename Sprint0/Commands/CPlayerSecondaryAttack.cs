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
        Game0 gameHere;
        public CPlayerSecondaryAttack(ILink secondaryAttack, Game0 game)
        {
            gameHere = game;
            this.secondaryAttack = secondaryAttack;
        }

        public void Execute()
        {
            secondaryAttack.Execute();
        }
    }
}
