using Microsoft.Xna.Framework;
using Sprint0.Sprites.SpriteFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.UtilityClasses;
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
        Mario mario;

        public AttackMario(Mario marioRef, IMarioState currentState, Vector2 position)
        {
            this.currentState = currentState;
            this.position = position;
            mario = marioRef;
        }

        public string ID => currentState.ID;

        public void Attack()
        {
            switch (currentState.ID)
            {
                case "RightMovingMario":
                case "RightIdleMario":
                case "RightJumpingMario":
                    position.X = position.X + GameUtilities.jumpXvalue;
                    GameObjectManager.Instance.AddToObjectList(
                        new Projectile(
                          SpriteFactory.Instance.GetSprite("fireball"), position, GameUtilities.fireBallVelocityX, 0, GameUtilities.fuseTime),1,1);
                    break;
                case "LeftMovingMario":
                case "LeftIdleMario":
                case "LeftJumpingMario":
                    position.X = position.X - GameUtilities.jumpXvalue;
                    GameObjectManager.Instance.AddToObjectList(
                        new Projectile(
                        SpriteFactory.Instance.GetSprite("fireball"), position, -GameUtilities.fireBallVelocityX, 0, GameUtilities.fuseTime),1,1);

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
        public void StopJump()
        {
            currentState.StopJump();
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
        public void UpBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - GameUtilities.upperBounceValue);
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 1);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - 1, mario.Position.Y);
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + 1, mario.Position.Y);
        }
        public void MarioBounce(Rectangle rectangle)
        {
           // We can't call velocity here, so I don't know how we get mario to bounce, for now it's just a feature that if you try to stomp an enemy while firing, you'll kill them instantly with a bounce
        }
        public void Update()
        {
            currentState.Update();
        }
    }
}
