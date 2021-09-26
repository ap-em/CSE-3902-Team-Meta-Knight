using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CPlayerPrimaryAttack : ICommand
    {
        ILink primaryAttack;
        Game0 gameHere;
        public CPlayerPrimaryAttack(ILink primaryAttack, Game0 game)
        {
            gameHere = game;
            this.primaryAttack = primaryAttack;
        }

        public void Execute()
        {
            primaryAttack.Execute();
        }
    }
}
