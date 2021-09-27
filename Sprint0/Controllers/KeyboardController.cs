using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Commands;
using System.Collections;

namespace Sprint0.Controllers
{
    class KeyboardController : IKeyboardController
    {
        private Dictionary<Keys, ICommand> pressableKeyMappings;
        private Dictionary<Keys, ICommand> releasableKeyMappings;
        private List<Keys> availableKeys;
        private KeyboardState oldState;

        /*
         *  Initializes the Control layout
         */
        public KeyboardController()
        {
            availableKeys = new List<Keys>();
            pressableKeyMappings = new Dictionary<Keys, ICommand>();
            releasableKeyMappings = new Dictionary<Keys, ICommand>();

            oldState = Keyboard.GetState();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            pressableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key); 
        }
        public void RegisterReleasableKey(Keys key, ICommand command)
        {
            releasableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key);
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

            foreach (Keys key in availableKeys)
            {
                //check if key was just released
                if (releasableKeyMappings.ContainsKey(key) && oldState.IsKeyDown(key) && newState.IsKeyUp(key))
                {
                    releasableKeyMappings[key].Execute();
                }
                //check if key was just pressed
                if(pressableKeyMappings.ContainsKey(key) && oldState.IsKeyUp(key) && newState.IsKeyDown(key))
                {
                    pressableKeyMappings[key].Execute();
                }
            }

            oldState = newState;
        }
    }
}
