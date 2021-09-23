using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*Owen Huston 9/22/21 */

namespace Sprint0.Enemies
{
    class E1StateMachine : IEnemyStateMachine
    {
        private bool facingLeft = true;
        private bool facingRight = false;
        private bool facingUp = false;
        private bool facingDown = false;
        
        private bool moving = false;
        private bool firing = false;

        private Enemy enemy;

        public E1StateMachine(Enemy enemy)
        {
            this.enemy = enemy;
            enemy.sprite = SpriteFactory.Instance.CreateE1IdleLeft();
        }
        
        public void MoveUp()
        {
            /*
            facingUp = true;
            facingDown = false;
            facingLeft = false;
            facingRight = false;
            */
        }
        public void MoveDown()
        {
            /*
            facingUp = false;
            facingDown = true;
            facingLeft = false;
            facingRight = false;
            */
        }
        public void MoveLeft()
        {
            /*
            facingUp = false;
            facingDown = false;
            facingLeft = true;
            facingRight = false;
            */
        }
        public void MoveRight()
        {
            /*
            facingUp = false;
            facingDown = false;
            facingLeft = false;
            facingRight = true;
            */
        }
        
        public void PrevEnemy()
        {
            enemy.stateMachine = new E3StateMachine(enemy);
        }
        public void NextEnemy()
        {
            enemy.stateMachine = new E2StateMachine(enemy);
        }
        
        public void FireProjectile()
        {
        /*
            //DECIDE whether we want to be able to fire while moving or not
            //if not set move to false

            if (facingLeft)
            {
                enemy.sprite = SpriteFactory.Instance.CreateE1IdleLeft();
            }
            else if (facingRight)
            {
                //enemy.sprite = SpriteFactory.Instance.CreateE1ShootRight();
            }
            else if (facingUp)
            {
                //enemy.sprite = SpriteFactory.Instance.CreateE1ShootUp();
            }
            else if (facingDown)
            {
                //enemy.sprite = SpriteFactory.Instance.CreateE1ShootDown();
            }
        */
        }
        private void MoveSprite()
        {
        /*
            if (facingLeft)
            {
                enemy.Move(-1, 0);
            }
            else if (facingRight)
            {
                enemy.Move(1, 0);
            }
            else if (facingUp)
            {
                enemy.Move(0, -1);
            }
            else if (facingDown)
            {
                enemy.Move(0, 1);
            }
        */
        }
        private void ChangeMovingSprite()
        {
        /*
            if (facingLeft)
            {
                //enemy.sprite = SpriteFactory.CreateE1MoveLeft();
            }
            else if (facingRight)
            {
                //enemy.sprite = SpriteFactory.CreateE1MoveRight();
            }
            else if (facingUp)
            {
                //enemy.sprite = SpriteFactory.CreateE1MoveUp();
            }
            else if (facingDown)
            {
                //enemy.sprite = SpriteFactory.CreateE1MoveDown();
            }
        */
        }
        private void ChangeNonMovingSprite()
        {
        /*
            if (facingLeft)
            {
                //enemy.sprite = SpriteFactory.CreateE1IdleLeft();
            }
            else if (facingRight)
            {
                //enemy.sprite = SpriteFactory.CreateE1IdleRight();
            }
            else if (facingUp)
            {
                //enemy.sprite = SpriteFactory.CreateE1IdleUp();
            }
            else if (facingDown)
            {
                //enemy.sprite = SpriteFactory.CreateE1IdleDown();
            }
        */
        }
        public void Update()
        {
        /*
            if (firing)
            {
                FireProjectile();
                if (moving) MoveSprite();
            }
            else
            {
                if (moving)
                {
                    ChangeMovingSprite();
                    MoveSprite();
                }
                else
                {
                    ChangeNonMovingSprite();
                }
            }
        */
        }
    }
}
