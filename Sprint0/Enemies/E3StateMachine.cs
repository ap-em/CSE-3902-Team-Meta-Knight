using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*Owen Huston 9/22/21 */

namespace Sprint0.Enemies
{
    class E3StateMachine : IEnemyStateMachine
    {

        private Enemy enemy;
        private ISprite sprite;

        public E3StateMachine(Enemy enemy)
        {
            this.enemy = enemy;
            SetSprite();
            enemy.SetSprite(sprite);
        }
        public void SetSprite()
        {
            bool moving = enemy.GetXVelocity() != 0 && enemy.GetYVelocity() != 0;

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
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3MovingLeft");
                    Debug.WriteLine("Enemy3MovingLeft");
                    break;

                case "right":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3MovingRight");
                    Debug.WriteLine("Enemy3MovingRight");
                    break;

                case "up":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3MovingUp");
                    Debug.WriteLine("Enemy3MovingUP");
                    break;

                case "down":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3MovingDown");
                    Debug.WriteLine("Enemy3MovingDown");
                    break;

                default:
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3MovingLeft");
                    Debug.WriteLine("Enemy3MovingLeft");
                    break;
            }
        }
        public void SetNonMovingSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction)
            {
                case "left":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3IdleLeft");
                    Debug.WriteLine("Enemy3IdleLeft");
                    break;

                case "right":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3IdleRight");
                    Debug.WriteLine("Enemy3IdleRight");
                    break;

                case "up":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3IdleUp");
                    Debug.WriteLine("Enemy3IdleUp");
                    break;

                case "down":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3IdleDown");
                    Debug.WriteLine("Enemy3IdleDown");
                    break;

                default:
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3IdleLeft");
                    Debug.WriteLine("Enemy3IdleLeft");
                    break;
            }
        }
        public void PrevEnemy()
        {
            enemy.SetStateMachine(new E2StateMachine(enemy));
        }
        public void NextEnemy()
        {
            enemy.SetStateMachine(new E1StateMachine(enemy));
        }
        public void SetFireProjectileSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction)
            {
                case "left":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3ShootLeft");
                    Debug.WriteLine("Enemy3ShootLeft");
                    break;

                case "right":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3ShootRight");
                    Debug.WriteLine("Enemy3ShootRight");
                    break;

                case "up":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3ShootUp");
                    Debug.WriteLine("Enemy3ShootUp");
                    break;

                case "down":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3ShootDown");
                    Debug.WriteLine("Enemy3ShootDown");
                    break;

                default:
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy3ShootLeft");
                    Debug.WriteLine("Enemy3ShootLeft");
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
