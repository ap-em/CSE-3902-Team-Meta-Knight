using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    class CMovePlayerRight : ICommand
    {
        private Game0 gameHere;
        public CMovePlayerRight(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.link.MoveRight();
        }
    }
}
