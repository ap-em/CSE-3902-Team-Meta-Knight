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
    class GamePadController : IGamePadController
    {
        private Dictionary<Buttons, ICommand> pressableButtonMappings;
        private Dictionary<Buttons, ICommand> releasableButtonMappings;
        private Dictionary<Buttons, ICommand> holdableButtonMappings;
        private List<Buttons> availableButtons;
        private GamePadState oldState;
        public GamePadController()
        {
            availableButtons = new List<Buttons>();
            pressableButtonMappings = new Dictionary<Buttons, ICommand>();
            releasableButtonMappings = new Dictionary<Buttons, ICommand>();
            holdableButtonMappings = new Dictionary<Buttons, ICommand>();

            oldState =GamePad.GetState(0);

            
        }

        public void ClearController()
        {
            availableButtons.Clear();
            pressableButtonMappings.Clear();
            releasableButtonMappings.Clear();
            holdableButtonMappings.Clear();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            if (pressableButtonMappings.ContainsKey(button)) pressableButtonMappings.Add(button, command);
            if (!availableButtons.Contains(button)) availableButtons.Add(button);
        }

        public void RegisterHoldableKey(Buttons button, ICommand command)
        {
            if (holdableButtonMappings.ContainsKey(button)) holdableButtonMappings.Add(button, command);
            if (!availableButtons.Contains(button)) availableButtons.Add(button);
        }

        public void RegisterReleasableKey(Buttons button, ICommand command)
        {
            if (releasableButtonMappings.ContainsKey(button)) releasableButtonMappings.Add(button, command);
            if (!availableButtons.Contains(button)) availableButtons.Add(button);
        }

        public void Update()
        {
            GamePadState newState = GamePad.GetState(0);


            foreach (Buttons button in availableButtons)
            {
                //check if key was just released
                if (releasableButtonMappings.ContainsKey(button) && oldState.IsButtonDown(button) && newState.IsButtonUp(button))
                {
                    releasableButtonMappings[button].Execute();
                }
                //check if key is being held
                if (holdableButtonMappings.ContainsKey(button) && oldState.IsButtonDown(button) && newState.IsButtonDown(button))
                {
                    holdableButtonMappings[button].Execute();
                }
                //check if key was just pressed
                if (pressableButtonMappings.ContainsKey(button) && oldState.IsButtonUp(button) && newState.IsButtonDown(button))
                {
                    pressableButtonMappings[button].Execute();
                }
            }

            oldState = newState;
        }
    }

}
