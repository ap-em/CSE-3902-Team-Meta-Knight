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
    /*OG Code written by Owen Huston, modifed by Owen Tishenkel to call enemy rather than game*/
    class CCyclePreviousEnemy : ICommand
    {
        private Game0 game;
        public CCyclePreviousEnemy(Game0 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.enemy.PrevSprite();
        }
    }
}
