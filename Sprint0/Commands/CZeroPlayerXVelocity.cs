using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CZeroPlayerXVelocity : ICommand
    {
        private Game0 gameHere;
        public CZeroPlayerXVelocity(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetXVelocity(0);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
