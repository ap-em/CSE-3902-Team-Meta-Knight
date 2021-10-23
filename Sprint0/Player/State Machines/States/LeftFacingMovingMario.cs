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
    public class LeftFacingMovingMario : IMarioState
    {
        public string ID { get; } = "LeftMovingMario";
        private Vector2 velocity = new Vector2(-4f, 0);

        private Mario mario;
        Boolean onBlock = false;

        public LeftFacingMovingMario(Mario marioRef)
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
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-4, -5), 15, true);
            mario.OnStateChange();
        }

        public void MoveLeft()
        {
            //No op
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void StopMovingHorizontal()
        {
            mario.currentState = new LeftFacingStaticMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void UpBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
            onBlock = true;
            StopMovingVertical();
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 1);
            velocity = new Vector2(velocity.X, 0);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - 1, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + 1, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void Update()
        {
            if (onBlock)
            {
                velocity = new Vector2(-4f, 0f);
            }
            else
            {
                velocity = new Vector2(-4f, 5 * .15f);
            }
            mario.MoveSprite(velocity);
        }
    }
}
