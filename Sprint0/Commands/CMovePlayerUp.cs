using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMovePlayerUp : ICommand
    {
        private Game0 gameHere;
        public CMovePlayerUp(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetDirection("up");
            gameHere.enemy.SetYVelocity(-1);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
