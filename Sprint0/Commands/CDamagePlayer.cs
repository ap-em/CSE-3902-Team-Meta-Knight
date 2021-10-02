using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    class CDamagePlayer : ICommand
    {
        ILink link;
        Game0 gameHere;
        public CDamagePlayer(ILink link, Game0 game)
        {
            gameHere = game;
            this.link = link;
        }

        public void Execute()
        {
            link.TakeDamage();
        }
    }
}
