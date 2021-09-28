using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*Owen Huston 9/22/21 */

namespace Sprint0.Enemies
{
    class E2StateMachine : IEnemyStateMachine
    {

        private Enemy enemy;
        private ISprite sprite;

        public E2StateMachine(Enemy enemy)
        {
            this.enemy = enemy;
            SetSprite();
            enemy.SetSprite(sprite);
        }
        public void SetSprite()
        {
            bool moving = enemy.GetXVelocity() != 0 || enemy.GetYVelocity() != 0;

            if (enemy.GetFiring())
            {
                SetFireProjectileSprite();
            }
            else
            {
                if (moving)
                {
                    SetMovingSprite();
                }
                else
                {
                    SetNonMovingSprite();
                }
            }
        }
        public void SetMovingSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction)
            {
                case "left":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2MovingLeft");
                    Debug.WriteLine("Enemy2MovingLeft");
                    break;

                case "right":
                    // sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2MovingRight");
                    Debug.WriteLine("Enemy2MovingRight");
                    break;

                case "up":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2MovingUp");
                    Debug.WriteLine("Enemy2MovingUp");
                    break;

                case "down":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2MovingDown");
                    Debug.WriteLine("Enemy2MovingDown");
                    break;

                default:
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2MovingLeft");
                    Debug.WriteLine("Enemy2MovingLeft");
                    break;
            }
        }
        public void SetNonMovingSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction)
            {
                case "left":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2IdleLeft");
                    Debug.WriteLine("Enemy2IdleLeft");
                    break;

                case "right":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2IdleRight");
                    Debug.WriteLine("Enemy2IdleRight");
                    break;

                case "up":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2IdleUp");
                    Debug.WriteLine("Enemy2IdleUp");
                    break;

                case "down":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2IdleDown");
                    Debug.WriteLine("Enemy2IdleDown");
                    break;

                default:
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2IdleLeft");
                    Debug.WriteLine("Enemy2IdleLeft");
                    break;
            }
        }
        public void PrevEnemy()
        {
            enemy.SetStateMachine(new E1StateMachine(enemy));
        }
        public void NextEnemy()
        {
            enemy.SetStateMachine(new E3StateMachine(enemy));
        }
        public void SetFireProjectileSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction)
            {
                case "left":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2ShootLeft");
                    Debug.WriteLine("Enemy2ShootLeft");
                    break;

                case "right":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2ShootRight");
                    Debug.WriteLine("Enemy2ShootRight");
                    break;

                case "up":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2ShootUp");
                    Debug.WriteLine("Enemy2ShootUp");
                    break;

                case "down":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2ShootDown");
                    Debug.WriteLine("Enemy2ShootDown");
                    break;

                default:
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy2ShootLeft");
                    Debug.WriteLine("Enemy2ShootLeft");
                    break;
            }
        }
        public void Update()
        {
            /*
             * 
            */
        }
    }
}
