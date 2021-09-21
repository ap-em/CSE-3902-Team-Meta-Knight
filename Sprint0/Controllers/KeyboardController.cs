using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
namespace Sprint0.Controllers
{
    class KeyboardController : IController
    {

        private Dictionary<Keys, ICommand> controllerMappings;

        /*
         *  Initializes the Control layout
         */
        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key)) // only updates if that key is in the dictionary
                {
                    controllerMappings[key].Execute();
                }

            }
        }


    }
}
