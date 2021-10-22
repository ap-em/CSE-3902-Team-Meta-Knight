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
        private Vector2 velocity= new Vector2(4f, 0);
        private Boolean onBlock = false;

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
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(4, -5), 15, true);
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
        public void UpBounce()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 12);
            onBlock = true;
            StopMovingVertical();
        }
        public void DownBounce()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 1);
            velocity = new Vector2(velocity.X, 0);
        }
        public void RightBounce()
        {
            mario.Position = new Vector2(mario.Position.X - 1, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void LeftBounce()
        {
            mario.Position = new Vector2(mario.Position.X + 1, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void Update()
        {
            velocity = velocity + new Vector2(0, 5 * .15f) ;
            if (onBlock)
            {
                velocity = new Vector2(velocity.X, 0f);
            }
            onBlock = false;
            mario.MoveSprite(velocity);
        }
    }
}
