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
    class AttackMario : IMarioState
    {

        IMarioState currentState;
        Vector2 position;

        public AttackMario(IMarioState currentState, Vector2 position)
        {
            this.currentState = currentState;
            this.position = position;
        }

        public string ID => currentState.ID;

        public void Attack()
        {
            switch (currentState.ID)
            {
                case "DownIdleMario":
                case "DownMovingMario":
                    position.Y = position.Y + 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("DownSword"), position, 0, 0, 6));
                    break;
                case "UpMovingMario":
                case "UpIdleMario":
                    position.Y = position.Y - 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("UpSword"), position, 0, 0, 6));
                    break;
                case "RightMovingMario":
                case "RightIdleMario":
                    position.X = position.X + 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("RightSword"), position, 0, 0, 6));
                    break;
                case "LeftMovingMario":
                case "LeftIdleMario":
                    position.X = position.X - 32;
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("LeftSword"), position, 0, 0, 6));
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

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }

        public void MoveRight()
        {
            currentState.MoveRight();
        }
        public void StopMovingHorizontal()
        {
            // no op
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void Update()
        {
            currentState.Update();
        }
    }
}
