using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CZeroPlayerYVelocity : ICommand
    {
        private Game0 gameHere;
        public CZeroPlayerYVelocity(Game0 game)
        {
            gameHere = game;
        }
        public void Execute()
        {
            gameHere.enemy.SetYVelocity(0);
            gameHere.enemy.SetStateMachineSprite();
        }
    }
}
