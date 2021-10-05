using Microsoft.Xna.Framework;
using Sprint0.Sprites.SpriteFactory;
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
namespace Sprint0.Concrete_Classes.State_Machines.States
{
    class SecondaryAttackLink : ILinkState
    {

        ILinkState currentState;
        Vector2 position;
        String currentSecondary;

        public SecondaryAttackLink(ILinkState currentState, Vector2 position, String currentSecondary)
        {
            this.currentState = currentState;
            this.position = position;
            this.currentSecondary = currentSecondary;
        }

        public string ID => currentState.ID;

        public void Attack()
        {
            switch (currentState.ID)
            {
                case "DownIdleLink":
                case "DownMovingLink":
                    position.Y = position.Y + 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite(currentSecondary), position, 0, 0, 20));
                    break;
                case "UpMovingLink":
                case "UpIdleLink":
                    position.Y = position.Y - 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite(currentSecondary), position, 0, 0, 20));
                    break;
                case "RightMovingLink":
                case "RightIdleLink":
                    position.X = position.X + 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite(currentSecondary), position, 0, 0, 20));
                    break;
                case "LeftMovingLink":
                case "LeftIdleLink":
                    position.X = position.X - 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite(currentSecondary), position, 0, 0, 20));
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
