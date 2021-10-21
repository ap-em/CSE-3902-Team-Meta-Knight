using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CCollide : ICommand
    {
        IGameObject collided;
        IGameObject collider;
        string direction;
        public CCollide(IGameObject collidedRef, IGameObject colliderRef, string direc)
        {
            collided = collidedRef;
            collider = colliderRef;
            direction = direc;
        }
        public void Execute()
        {
            /*
             * Here we know that two objects have collided, and so we need to refernce the data table to see 
             * how the two objects handle colliding with eachother. 
             * 
             * Right now, I'm only going to create a Bounce command for the p
             */
            Console.WriteLine("COLLISION CAUSED");
            /*
             * Instantiate and execute a command from data table based on block+game object from data table
             * Right now it's only calling collide, which is for walls, not enemies. 
             */
            /*
             * Instantiate a player bounce command?
             */

        }
    }
}
