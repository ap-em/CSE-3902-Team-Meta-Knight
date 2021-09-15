using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class MovementController
    {
        int verticalSpeed = 0;
        int horizontalSpeed = 0;
        int horizontalDirection = 1;
        Game1 myGame;
        ICommand[] commands = new ICommand[5];
        int commandIndex = 1;
        public MovementController(Game1 game)
        {
            myGame = game;
            commands[0] = new QuitGame(myGame);
            commands[1] = new Idle(myGame);
            commands[2] = new Crouch(myGame);
            commands[3] = new VerticalMove(myGame);
            commands[4] = new HorizontalMove(myGame);
        }
        public void SetSpeed()
        {
            if (myGame.position.Y < 200) verticalSpeed = 1;
            else if (myGame.position.Y > 260) verticalSpeed = -1;

            if (myGame.position.X < 350)
            {
                horizontalDirection = 1;
                horizontalSpeed = 1;
            }
            else if (myGame.position.X > 450)
            {
                horizontalDirection = -1;
                horizontalSpeed = -1;
            }
        }
        public void SetPosition()
        {
            myGame.mario.UpdateDirection(horizontalDirection);
            myGame.position = new Vector2(myGame.position.X + 2 * horizontalSpeed, myGame.position.Y + 2 * verticalSpeed);
        }
        public void SetVerticalSpeed(int speed)
        {
            verticalSpeed = speed;
        }
        public void SetHorizontalSpeed(int speed)
        {
            horizontalSpeed = speed;
        }
        public int GetHorizontalDirection()
        {
            return horizontalDirection;
        }
        public void SetIndexOfCurrentCommand(int index)
        {
            commandIndex = index;
        }
        public int GetIndexOfCurrentCommand()
        {
            return commandIndex;
        }
        public void RunCommand()
        {
            commands[commandIndex].Execute();
        }
        public void Update()
        {
            SetSpeed();
            SetPosition();
        }
    }
}
