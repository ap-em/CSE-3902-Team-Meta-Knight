using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    class RightFacingMovingMario : IMarioState
    {
        public string ID  { get; }= "RightMovingMario";
        private Mario mario;
        private const float moveVelocity= 2f;

        public RightFacingMovingMario(Mario marioRef)
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
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(2, -5), 15, true);
            mario.OnStateChange();
        }
        public void MoveLeft()
        {
            mario.currentState = new LeftFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            //No op
        }
        public void StopMovingHorizontal()
        {
            mario.currentState = new RightFacingStaticMario(mario);
            mario.OnStateChange();
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
                    mario.currentState = new RightFacingStaticMario(mario);
                    mario.OnStateChange() ;
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {            
            mario.MoveSprite(new Vector2(moveVelocity, 0f));
            /*
             * Try to apply downwards velocity? Walking off an edge should make the player fall.
             *  If theyre on ground their velocity should be stopped by command to bounce from bottom.
             */
        }
    }
}
