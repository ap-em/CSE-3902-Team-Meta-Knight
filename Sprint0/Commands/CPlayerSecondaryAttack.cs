using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    class CPlayerSecondaryAttack : ICommand
    {
        ILink secondaryAttack;
        Game0 gameHere;
        String attackType;
        public CPlayerSecondaryAttack(ILink secondaryAttack, Game0 game, String attackType)
        {
            gameHere = game;
            this.secondaryAttack = secondaryAttack;
            this.attackType = attackType;
        }

        public void Execute()
        {
            secondaryAttack.SecondaryAttack(attackType);
        }
    }
}
