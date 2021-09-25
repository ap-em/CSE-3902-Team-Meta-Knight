using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMovePlayerRight : ICommand
    {
        private Game0 gameHere;
        public CMovePlayerRight(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetDirection("right");
            gameHere.enemy.SetXVelocity(1);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
