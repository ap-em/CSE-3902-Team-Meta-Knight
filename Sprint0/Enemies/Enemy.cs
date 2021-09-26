using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0.Enemies
{
    class Enemy : IEnemy
    {
        private IEnemyStateMachine stateMachine;
        private ISprite sprite;
        private Vector2 location = new Vector2(100, 100);
        private Game0 gameHere;
        private String direction = "left"; 
        private int XVelocity = 0;
        private int YVelocity = 0;
        private bool firing = false;

        public Enemy(Game0 game)
        { 
            gameHere = game;
            stateMachine = new E1StateMachine(this);
        }
        public String GetDirection()
        {
            return direction;
        }
        public void PrevEnemy()
        {
            stateMachine.PrevEnemy();
        }
        public void NextEnemy()
        {
            stateMachine.NextEnemy();
        }
        public void Draw()
        {
           // sprite.Draw(gameHere.spriteBatch, location);
        }
        public void Move(int x, int y)
        {
            location = new Vector2(location.X + XVelocity, location.Y + YVelocity);
        }
        public void SetDirection(String direction)
        {
            this.direction = direction;
        }
        public int GetXVelocity()
        {
            return XVelocity;
        }
        public void SetXVelocity(int x)
        {
            XVelocity = x;
        }
        public int GetYVelocity()
        {
            return YVelocity;
        }
        public void SetYVelocity(int y)
        {
            YVelocity = y;
        }
        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void SetStateMachineSprite()
        {
            stateMachine.SetSprite();
        }
        public void SetStateMachine(IEnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void FireProjectile()
        {
            stateMachine.SetFireProjectileSprite();
        }
        public bool GetFiring()
        {
            return firing;
        }
        public void SetFiring(bool fire)
        {
            firing = fire;
        }
        public void Update()
        {
            Move(XVelocity, YVelocity);
            //update animation on sprite
           // sprite.Update();
        }
    }
}
