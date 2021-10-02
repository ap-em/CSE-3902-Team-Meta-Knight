using Microsoft.Xna.Framework;
using Sprint0.Sprites.SpriteFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Concrete_Classes.State_Machines.States
{
    class AttackLink : ILinkState
    {

        ILinkState currentState;
        Vector2 position;

        public AttackLink(ILinkState currentState, Vector2 position)
        {
            this.currentState = currentState;
            this.position = position;
        }

        public string ID => currentState.ID;

        public void Attack()
        {
            switch (currentState.ID)
            {
                case "DownIdleLink":
                case "DownMovingLink":
                    position.Y = position.Y + 16;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("DownSword"), position, 0, 0, 3));
                    break;
                case "UpMovingLink":
                case "UpIdleLink":
                    position.Y = position.Y - 16;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("UpSword"), position, 0, 0, 3));
                    break;
                case "RightMovingLink":
                case "RightIdleLink":
                    position.X = position.X + 16;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("RightSword"), position, 0, 0, 3));
                    break;
                case "LeftMovingLink":
                case "LeftIdleLink":
                    position.X = position.X + 16;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("DownSword"), position, 0, 0, 3));
                    break;

            }
            
        }

        public void Crouch()
        {
            currentState.Crouch();
        }

        public void Jump()
        {
            currentState.Jump();
        }

        public void MoveDown()
        {
            currentState.MoveDown();
        }

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }

        public void MoveRight()
        {
            currentState.MoveRight();
        }

        public void MoveUp()
        {
            currentState.MoveUp();
        }

        public void StopMoving(string sourceDirection)
        {
            currentState.StopMoving(sourceDirection);
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}
