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
             * 
             * PROBLEM: The command that would be executed here would be CBouncePlayer, for mario hitting a wall. This just calls mario.Bounce()
             * However, even though we know the type, how are we supposed to get a reference to mario, since that command needs
             * a refernce to mario in the constructor? 
             * We have a refernce to Mario as a game object, so do we have to have to make Bounce() a function in IGameObject?
             * 
             */

        }
    }
}
