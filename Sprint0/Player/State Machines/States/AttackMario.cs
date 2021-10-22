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
                case "RightMovingMario":
                case "RightIdleMario":
                case "RightJumpingMario":
                    position.X = position.X + 5;
                    GameObjectManager.Instance.AddToProjectileList(
                        new Projectile(SpriteFactory.Instance.GetSprite("fireball"), position, 10, 0, 30));
                    break;
                case "LeftMovingMario":
                case "LeftIdleMario":
                case "LeftJumpingMario":
                    position.X = position.X - 5;
                    GameObjectManager.Instance.AddToProjectileList(
                        new Projectile(SpriteFactory.Instance.GetSprite("fireball"), position, -10, 0, 30));
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
