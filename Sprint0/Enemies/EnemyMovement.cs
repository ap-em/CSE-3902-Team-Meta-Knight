﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class EnemyMovement : IEnemyMovement
    {
        private Vector2 location;
        private String direction = "Left";
        private int XVelocity = 0;
        private int YVelocity = 0;
        private Game0 game;
        private Enemy enemy;

        public EnemyMovement(Enemy enemy, Game0 game, Vector2 location)
        {
            this.enemy = enemy;
            this.game = game;
            this.location = location;
        }
        public String GetDirection()
        {
            return direction;
        }
        public void Move()
        {
            location = new Vector2(location.X + XVelocity, location.Y + YVelocity);
        }
        public void MoveRight()
        {
            direction = "Right";
            XVelocity = 1;
        }
        public void MoveLeft()
        {
            direction = "Left";
            XVelocity = -1;
        }
        public void MoveUp()
        {
            direction = "Up";
            YVelocity = -1;
        }
        public void MoveDown()
        {
            direction = "Down";
            YVelocity = 1;
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
        public Vector2 GetLocation()
        {
            return location;
        }
        public void Update()
        {

        }
    }
}
