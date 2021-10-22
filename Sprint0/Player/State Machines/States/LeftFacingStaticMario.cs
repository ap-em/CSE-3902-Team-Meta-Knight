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
    public class LeftFacingStaticMario : IMarioState
    {
        private Mario mario;
        public string ID { get; } = "LeftIdleMario";
        private Vector2 velocity = new Vector2(0, 0);
        private Boolean onBlock = false;

        public LeftFacingStaticMario(Mario marioRef)
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
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(0, -5), 15, true);
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
        public void UpBounce()
        {
            onBlock = true;
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 14);
            StopMovingVertical();
        }
        public void DownBounce()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 1);
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
         velocity = velocity + new Vector2(0, 5 * .15f);
           if (onBlock)
           {
           velocity = new Vector2(0f, 0f);
           }
         onBlock = false;
         mario.MoveSprite(velocity);
        }
    }
}
