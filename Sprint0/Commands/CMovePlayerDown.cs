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
    /*Owen Tishenkel 2021 CSE 3902*/
    class CMovePlayerDown : ICommand
    {
        private static Game0 gameHere;
        public CMovePlayerDown(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.link.MoveDown();
        }
    }
}
