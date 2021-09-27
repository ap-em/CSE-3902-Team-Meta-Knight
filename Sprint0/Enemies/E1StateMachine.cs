using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*Owen Huston 9/22/21 */

namespace Sprint0.Enemies
{
    class E1StateMachine : IEnemyStateMachine
    { 

        private Enemy enemy;
        private ISprite sprite;

        public E1StateMachine(Enemy enemy)
        {
            this.enemy = enemy;
            SetSprite();
            enemy.SetSprite(sprite);
        }
        public void SetSprite()
        {
            bool moving = enemy.GetXVelocity() != 0 || enemy.GetYVelocity() != 0;

            if(enemy.GetFiring())
            {
                SetFireProjectileSprite();
            }
            else 
            { 
                if(moving)
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
            switch (direction) {  
            case "left":
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1MovingLeft");
                    Debug.WriteLine("Enemy1MovingLeft");
                break;
  
            case "right":
                    //sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1MovingRight");
                    Debug.WriteLine("Enemy1MovingRight");
                    break;

            case "up":
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1MovingUp");
                    Debug.WriteLine("Enemy1MovingUP");
                    break;

            case "down":
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1MovingDown");
                    Debug.WriteLine("Enemy1MovingDown");
                    break;

            default:
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1MovingLeft");
                    Debug.WriteLine("Enemy1MovingLeft");
                    break;
            }
        }
        public void SetNonMovingSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction) {  
            case "left":
//            sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1IdleLeft");
                    Debug.WriteLine("Enemy1IdleLeft");
                    break;
  
            case "right":
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1IdleRight");
                    Debug.WriteLine("Enemy1IdleRight");
                    break;

            case "up":
 //               sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1IdleUp");
                    Debug.WriteLine("Enemy1IdleUp");
                    break;

            case "down":
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1IdleDown");
                    Debug.WriteLine("Enemy1IdleDown");
                    break;

            default:
//                sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1IdleLeft");
                    Debug.WriteLine("Enemy1IdleLeft");
                    break;
            }
        }
        public void PrevEnemy()
        {
            enemy.SetStateMachine(new E3StateMachine(enemy));
        }
        public void NextEnemy()
        {
            enemy.SetStateMachine(new E2StateMachine(enemy));
        }
        public void SetFireProjectileSprite()
        {
            String direction = enemy.GetDirection();
            switch (direction) {  
            case "left":
 //           sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1ShootLeft");
                    Debug.WriteLine("Enemy1ShootLeft");
                    break;
  
            case "right":
 //               sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1ShootRight");
                    Debug.WriteLine("Enemy1ShootRight");
                    break;

            case "up":
//               sprite =  SpriteFactory.Instance.CreateNewSprite("Enemy1ShootUp");
                    Debug.WriteLine("Enemy1ShootUp");
                    break;

            case "down":
 //               sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1ShootDown");
                    Debug.WriteLine("Enemy1ShootDown");
                    break;

            default:
//              sprite = SpriteFactory.Instance.CreateNewSprite("Enemy1ShootLeft");
                    Debug.WriteLine("Enemy1ShootLeft");
                    break;
            }
        }
        public void Update()
        {

        }
    }
}
