using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Commands;
namespace Sprint0.Controllers
{
    class KeyboardController : IKeyboardController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private KeyboardState oldState;
        private ICommand zeroXVelocity;
        private ICommand zeroYVelocity;

        /*
         *  Initializes the Control layout
         */
        public KeyboardController()
        {

            controllerMappings = new Dictionary<Keys, ICommand>();

            oldState = Keyboard.GetState();
        }
        public void SetZeroXVelocityCommand(ICommand command)
        {
            zeroXVelocity = command;
        }
        public void SetZeroYVelocityCommand(ICommand command)
        {
            zeroYVelocity = command;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            Keys[] pressedKeys = newState.GetPressedKeys();
            
            foreach(Keys key in controllerMappings.Keys)
            {
                //key was just released
                if (oldState.IsKeyDown(key) && newState.IsKeyUp(key))
                {
                    if (key.Equals(Keys.W) || key.Equals(Keys.S))
                    {
                        zeroYVelocity.Execute();
                    }
                    else if (key.Equals(Keys.A) || key.Equals(Keys.D))
                    {
                        zeroXVelocity.Execute();
                    }
                }
                //check if key is just now pressed
                else if(!oldState.IsKeyDown(key) && newState.IsKeyDown(key))
                {
                    controllerMappings[key].Execute();
                }
            }

            oldState = newState;
        }
    }
}
