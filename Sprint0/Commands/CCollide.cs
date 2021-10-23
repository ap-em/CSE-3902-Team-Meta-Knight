using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CCollide : ICommand
    {
        IGameObject Collided;
        IGameObject Collider;
        String direction;
        Rectangle rectangle;

        public CCollide(IGameObject collided, IGameObject collider, String collisionSide, Rectangle rectangle)
        {
            Collided = collided;
            Collider = collider;
            direction = collisionSide;
            this.rectangle = rectangle;
        }
        public void Execute()
        {
            CollisionResponse.Instance.CollisionOccurrence(Collider, Collided, direction,rectangle);
        }
    }
}
