using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Cycle;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Controllers;
using Sprint0.UtilityClasses;

/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0.Enemies
{
    public class Enemy : IEnemy, ICyclable, IGameObject, IMovable, IUpdate, IDraw, ICollidable
    {
        private IKeyboardController keyboard;
        private IEnemyMovement enemyMovement;
        private ICycleStateMachine cycleStateMachine;
        private ISprite sprite;
        private String enemyType = GameUtilities.emptyString ;
        private String spriteName = GameUtilities.emptyString;
        private bool firing = false;
        private int firingTimer = 4;

        public Vector2 Position { get => enemyMovement.Position; set => throw new NotImplementedException(); }

        public ISprite Sprite => sprite;

        public Enemy(String spriteName, Vector2 position)
        {
            enemyType = spriteName;
            enemyMovement = new EnemyMovement(this, position);
            this.spriteName = enemyMovement.GetDirection() + "Idle" + enemyType;
            sprite = SpriteFactory.Instance.GetSprite(this.spriteName);
            cycleStateMachine = new CycleStateMachine(this);
            keyboard = ControllerLoader.Instance.SetUpEnemyKeyboard(this); 
        }
        public void PrevSprite()
        {
            cycleStateMachine.PrevSprite();
            SetSprite(enemyType);
        }
        public void NextSprite()
        {
            cycleStateMachine.PrevSprite();
            SetSprite(enemyType);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, enemyMovement.GetLocation());
        }
        public void SetSprite(String enemyType)
        {
            this.enemyType = enemyType;
            bool moving = enemyMovement.GetXVelocity() != 0 || enemyMovement.GetYVelocity() != 0;
            String direction = enemyMovement.GetDirection();
            if (firing)
            {
                // spriteString = enemyMovement.GetDirection() + "Shooting" + enemy.GetEnemyType(); Get to this once we implment an enemy that has a unique attack animation  
            }
            else
            {
                if (moving)
                {
                    this.spriteName = enemyMovement.GetDirection() + "Moving" + enemyType;
                }
                else
                {
                    this.spriteName = enemyMovement.GetDirection() + "Idle" + enemyType;
                }
            }

            this.sprite = SpriteFactory.Instance.GetSprite(this.spriteName);
        }
        public String GetSpriteName()
        {
            return enemyType;
        }
        public void SetStateMachineSprite()
        {
           // stateMachine.SetSprite();
        }
        public void FireProjectile()
        {
            if (!firing)
            {
                firing = true;
                ProjectileCreator.Instance.CreateProjectile(enemyType, enemyMovement.GetDirection(), enemyMovement.GetLocation());
            }
        }
        public bool GetFiring()
        {
            return firing;
        }
        public void SetFiring(bool fire)
        {
            firing = fire;
        }

        public void MoveRight()
        {
            enemyMovement.MoveRight();
            SetSprite(enemyType);
        }

        public void MoveLeft()
        {
            enemyMovement.MoveLeft();
            SetSprite(enemyType);
        }

        public void SetXVelocity(int x)
        {
            enemyMovement.SetXVelocity(x);
            SetSprite(enemyType);
        }

        public void SetYVelocity(int y)
        {
            enemyMovement.SetYVelocity(y);
            SetSprite(enemyType);
        }
        public void Update()
        {
            // this is to reset to a different sprite after doing projectil throwing
            // animation after a few frames

            if(firing)
            {
                firingTimer--;
            }
            if (firingTimer < 0)
            {
                firing = false;
                firingTimer = 4;
            }

            enemyMovement.Move();
            sprite.Update();
            keyboard.Update();
        }

        public bool GetGrounded()
        {
            //todo
            return true;
        }

        public void SetGrounded(bool grounded)
        {
            //todo
        }

        public void UpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DownBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void RightBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void LeftBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }
}
