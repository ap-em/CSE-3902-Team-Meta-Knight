using Microsoft.Xna.Framework;
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
namespace Sprint0
{
    class RightFacingStaticMario : IMarioState
    {
        private Mario mario;
        public string ID { get; } = "RightIdleMario";

        public RightFacingStaticMario(Mario marioRef)
        {
            mario = marioRef;
        }
        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Crouch()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(0, -5), 15, true);
            mario.OnStateChange();
        }

        public void MoveLeft()
        {
            mario.currentState = new LeftFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingHorizontal()
        {
           // no op
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void Bounce(string direction)
        {
            switch (direction)
            {
                case "up":
                    break;
                case "down":
                    //RESET VELOCITY, BLOCK UNDER PLAYER
                    break;
                case "left":
                    break;
                case "right":
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
            /*
             * Try to apply downwards velocity? Walking off an edge should make the player fall.
             *  If theyre on ground their velocity should be stopped by command to bounce from bottom.
             */
            //No op ?
        }
    }
}
