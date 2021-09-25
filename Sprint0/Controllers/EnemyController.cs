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
    class EnemyController : IKeyboardController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Keys oldKey;
        private ICommand zeroXVelocity;
        private ICommand zeroYVelocity;
        private List<Keys> availableKeys;

        /*
         *  Initializes the Control layout
         */
        public EnemyController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            availableKeys = new List<Keys>();
            oldKey = Keys.None;
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
        public void SetAvailableKeys()
        {
            foreach(Keys key in controllerMappings.Keys)
            {
                availableKeys.Add(key);
            }
            availableKeys.Add(Keys.None);
        }
        public void Update()
        {
            //choose a random key to press out of available keys
            Keys newKey = availableKeys.ToArray()[new Random().Next(0,availableKeys.Count)];

            //if new input
            if (oldKey != newKey)
            {
                if (oldKey.Equals(Keys.W) || oldKey.Equals(Keys.S))
                {
                    zeroYVelocity.Execute();
                }
                else if (oldKey.Equals(Keys.A) || oldKey.Equals(Keys.D))
                {
                    zeroXVelocity.Execute();
                }
                if (controllerMappings.ContainsKey(newKey))
                {
                    controllerMappings[newKey].Execute();
                }
            }

            oldKey = newKey;
        }
    }
}
