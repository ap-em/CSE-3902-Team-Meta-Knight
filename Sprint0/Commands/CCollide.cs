using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCollide : ICommand
    {
        public CCollide(IGameObject collided, IGameObject collider, String collisionSide)
        {

        }
        public void Execute()
        {
            //Based on non-existant data sheet
        }
    }
}
