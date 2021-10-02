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
    class CZeroPlayerXVelocity : ICommand
    {
        private Game0 gameHere;
        private string direction;
        public CZeroPlayerXVelocity(Game0 game, string directionRef)
        {
            gameHere = game;
            direction = directionRef;
        }
        public void Execute()
        {
            gameHere.link.StopMoving(direction);
        }
    }
}
