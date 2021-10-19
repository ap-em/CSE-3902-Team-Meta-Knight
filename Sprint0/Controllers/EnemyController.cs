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
    class EnemyController : IKeyboardController
    {
        private Dictionary<Keys, ICommand> pressableKeyMappings;
        private Dictionary<Keys, ICommand> releasableKeyMappings;
        private Dictionary<Keys, ICommand> holdableKeyMappings;
        private List<Keys> availableKeys;
        private Keys oldKey;
        private int currentTime = 0;
        private int waitTime = 50;

        /*
         *  Initializes the Control layout
         */
        public EnemyController()
        {
            pressableKeyMappings = new Dictionary<Keys, ICommand>();
            releasableKeyMappings = new Dictionary<Keys, ICommand>();
            holdableKeyMappings = new Dictionary<Keys, ICommand>();
            availableKeys = new List<Keys>();
            availableKeys.Add(Keys.None);
            oldKey = Keys.None;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            if(!pressableKeyMappings.ContainsKey(key)) pressableKeyMappings.Add(key, command);
            if(!availableKeys.Contains(key)) availableKeys.Add(key);
        }
        public void RegisterHoldableKey(Keys key, ICommand command)
        {
            if(!holdableKeyMappings.ContainsKey(key))holdableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key);
        }
        public void RegisterReleasableKey(Keys key, ICommand command)
        {
            if (!releasableKeyMappings.ContainsKey(key))releasableKeyMappings.Add(key, command);
            if (!availableKeys.Contains(key)) availableKeys.Add(key);
        }
        public void ClearController()
        {
            availableKeys.Clear();
            pressableKeyMappings.Clear();
            releasableKeyMappings.Clear();
            holdableKeyMappings.Clear();
        }
        public void Update()
        {
            //wait for a few updates before choosing a new key
            if (currentTime > waitTime)
            {
                currentTime=0;
                //choose a random key to press out of available keys
                Keys newKey = availableKeys.ToArray()[new Random().Next(0, availableKeys.Count)];

                //if new input
                if (oldKey != newKey)
                {
                    //released old key
                    if (releasableKeyMappings.ContainsKey(oldKey))
                    {
                        releasableKeyMappings[oldKey].Execute();
                    }
                    //pressed new key
                    if (pressableKeyMappings.ContainsKey(newKey))
                    {
                        pressableKeyMappings[newKey].Execute();
                    }
                }

                oldKey = newKey;
            }
            else
            {
                currentTime++;
            }
        }
    }
}
