using Sprint0.Interfaces;
using Sprint0.Items;
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
    class CResetItem : ICommand
    {

        /*gameHere provides access to game for the purposes of reseting many of the things that it contains*/
        Game0 gameHere;
        /*CResetItem is a subcommand for CReset which resets the item displayed to the original item*/
        public CResetItem(Game0 game)
        {
            gameHere = game;
        }

        public void Execute()
        {
            gameHere.item = new Item(gameHere);
        }
    }
}
