using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCollide : ICommand
    {
        IGameObject Collided;
        IGameObject Collider;
        String direction;

        public CCollide(IGameObject collided, IGameObject collider, String collisionSide)
        {
            Collided = collided;
            Collider = collider;
            direction = collisionSide;
        }
        public void Execute()
        {
            CollisionResponse.Instance.CollisionOcurrance(Collider, Collided, direction);
        }
    }
}
