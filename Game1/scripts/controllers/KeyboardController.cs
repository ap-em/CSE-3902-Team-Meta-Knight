using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
	class KeyboardController : IController
	{
		private Dictionary<Keys, int> controllerMappings;
		private Game1 myGame;
		private KeyboardState oldState;
		public KeyboardController(Game1 game)
		{
			myGame = game;
			controllerMappings = new Dictionary<Keys, int>();
			
			// 0 to quit game
			controllerMappings.Add(Keys.D0, 0);

			// 1 to idle
			controllerMappings.Add(Keys.D1, 1);

			// 2 to crouch
			controllerMappings.Add(Keys.D2, 2);

			// 3 to move vertically
			controllerMappings.Add(Keys.D3, 3);

			// 4 to move horizontally while animated
			controllerMappings.Add(Keys.D4, 4);

			oldState = Keyboard.GetState();
		}
		/*
		public void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}
		*/
		public void Update()
		{
			KeyboardState newState = Keyboard.GetState();
			Keys[] pressedKeys = newState.GetPressedKeys();


			foreach (Keys key in pressedKeys)
			{
				if (!oldState.IsKeyDown(key) && controllerMappings.ContainsKey(key))
				{
					//only run if the command isnt running already
					if (myGame.characterController.GetIndexOfCurrentCommand() != controllerMappings[key])
					{
						myGame.characterController.SetIndexOfCurrentCommand(controllerMappings[key]);
						myGame.characterController.RunCommand();
					}
				}
			}
			oldState = newState;
		}
	}
}