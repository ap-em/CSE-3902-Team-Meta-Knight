using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Commands;
using System.Collections;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Controllers
{
    class KeyboardController : IKeyboardController
    {
        private Dictionary<Keys, ICommand> pressableKeyMappings;
        private Dictionary<Keys, ICommand> releasableKeyMappings;
        private Dictionary<Keys, ICommand> holdableKeyMappings;
        private List<Keys> availableKeys;
        private KeyboardState oldState;
        public bool lockInput = false;
        /*instance used for player, allows for locking player out of controls for predefined sequences
         such as the flag pole slide on win*/

        /*
         *  Initializes the Control layout
         */
        public KeyboardController()
        {
            availableKeys = new List<Keys>();
            pressableKeyMappings = new Dictionary<Keys, ICommand>();
            releasableKeyMappings = new Dictionary<Keys, ICommand>();
            holdableKeyMappings = new Dictionary<Keys, ICommand>();

            oldState = Keyboard.GetState();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            if(!pressableKeyMappings.ContainsKey(key))pressableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key); 
        }
        public void RegisterReleasableKey(Keys key, ICommand command)
        {
            if(!releasableKeyMappings.ContainsKey(key))releasableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key);
        }
        public void RegisterHoldableKey(Keys key, ICommand command)
        {
            if (!holdableKeyMappings.ContainsKey(key)) holdableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key);
        }
        public void ClearController()
        {
            availableKeys.Clear();
            pressableKeyMappings.Clear();
            releasableKeyMappings.Clear();
            holdableKeyMappings.Clear();
        }
        public void SetLockInput(bool lockInput)
        {
            this.lockInput = lockInput;
        }
        public bool GetLockInput()
        {
            return lockInput;
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            //Preventing player movement if keyboard is locked
            if (lockInput == false)
            {
           
            foreach (Keys key in availableKeys)
            {
                //check if key was just released
                if (releasableKeyMappings.ContainsKey(key) && oldState.IsKeyDown(key) && newState.IsKeyUp(key))
                {
                    releasableKeyMappings[key].Execute();
                }
                //check if key is being held
                if(holdableKeyMappings.ContainsKey(key) && oldState.IsKeyDown(key) && newState.IsKeyDown(key))
                {
                    holdableKeyMappings[key].Execute();
                }
                //check if key was just pressed
                if(pressableKeyMappings.ContainsKey(key) && oldState.IsKeyUp(key) && newState.IsKeyDown(key))
                {
                    pressableKeyMappings[key].Execute();
                }
            }
            }

            oldState = newState;
        }
    }
}
