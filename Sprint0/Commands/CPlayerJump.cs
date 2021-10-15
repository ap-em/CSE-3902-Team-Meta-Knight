using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
    /*Owen Tishenkel 2021 CSE 3902*/
    class CPlayerJump : ICommand
    {
        private Game0 gameHere;
        public CPlayerJump(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.link.Jump();

        }
    }
}
