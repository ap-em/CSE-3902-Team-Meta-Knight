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
    public class UpFacingMovingLink : ILinkState
    {
        public string ID { get; } = "UpMovingLink";
        private Link link;
        private const float moveVelocity = 2f;

        public UpFacingMovingLink(Link linkRef)
        {
            link = linkRef;
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
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            link.currentState = new DownFacingMovingLink(link);
            link.OnStateChange();
        }

        public void MoveLeft()
        {
            link.currentState = new LeftFacingMovingLink(link);
            link.OnStateChange();
        }

        public void MoveRight()
        {
            link.currentState = new RightFacingMovingLink(link);
            link.OnStateChange();
        }

        public void MoveUp()
        {
            //No op
        }

        public void StopMoving(string sourceDirection)
        {
            if (sourceDirection=="Up")
            {
                link.currentState = new UpFacingStaticLink(link);
                link.OnStateChange();
            }
        }

        public void Update()
        {
            link.MoveSprite(new Vector2(0f, -1*moveVelocity));
        }
    }
}
