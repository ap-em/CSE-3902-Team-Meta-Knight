using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CMoveEnemyUp : ICommand
    {
        private Game0 gameHere;
        public CMoveEnemyUp(Game0 game)
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
