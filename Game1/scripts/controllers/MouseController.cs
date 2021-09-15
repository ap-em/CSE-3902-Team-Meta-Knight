using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class MouseController : IController
    {

        private Game1 myGame;
        private int ScreenWidth;
        private int ScreenHeight;

        MouseState oldState = Mouse.GetState();

        public MouseController(Game1 game)
        {
            myGame = game;
            ScreenWidth = myGame.graphics.GraphicsDevice.Viewport.Width;
            ScreenHeight = myGame.graphics.GraphicsDevice.Viewport.Height;

        }
        public void ProcessInput(int commandNumber)
        {
            //only run command if its not already running
            if (myGame.characterController.GetIndexOfCurrentCommand() != commandNumber)
            {
                myGame.characterController.SetIndexOfCurrentCommand(commandNumber);
                myGame.characterController.RunCommand();
            }
        }
        public void GetInput(MouseState newState)
        {
            if (oldState.LeftButton == ButtonState.Released && newState.LeftButton == ButtonState.Pressed)
            {
                //top left
                if (newState.X < ScreenWidth / 2 && newState.Y < ScreenHeight / 2)
                {
                    //run command 1
                    ProcessInput(1);
                }
                //top right
                else if (newState.X >= ScreenWidth / 2 && newState.Y < ScreenHeight / 2)
                {
                    ProcessInput(2);
                }
                //bottom left
                else if (newState.X < ScreenWidth / 2 && newState.Y >= ScreenHeight / 2)
                {
                    ProcessInput(3);
                }
                //bottom right
                else if (newState.X >= ScreenWidth / 2 && newState.Y >= ScreenHeight / 2)
                {
                    ProcessInput(4);
                }
            }
            if (newState.RightButton == ButtonState.Pressed)
            {
                ProcessInput(0);
            }
        }
        
        public void Update()
        {
            MouseState newState = Mouse.GetState();
            GetInput(newState);

            oldState = newState;
        }
    }
}
