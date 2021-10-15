using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Interfaces;
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
    class CResetBlock : ICommand
    {
        /*gameHere provides access to game for the purposes of reseting many of the things that it contains*/
        Game0 gameHere;

        /*CResetBlock is a subcommand for CReset which resets the Block displayed to the original Block*/
        public CResetBlock(Game0 game)
        {
            gameHere = game;
        }

        public void Execute()
        {
            gameHere.block = new Block("OrangeBlock", new Vector2(100,100));
        }
    }
}
