using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Commands;
namespace Sprint0.Controllers
{
    class MouseController : IMouseController
    {
        MouseState state;
        private Dictionary<Rectangle, ICommand> mouseMappings;
        private List<Rectangle> rectangles;
        private Game0 gameHere;
        private ICommand zeroXVelocity;
        private ICommand zeroYVelocity;

        public MouseController(Game0 game)
        {
            gameHere = game;
            mouseMappings = new Dictionary<Rectangle, ICommand>();
            rectangles = new List<Rectangle>();
            state = Mouse.GetState();

        }
        public void RegisterCommand(Rectangle rectangle, ICommand command)
        {
            mouseMappings.Add(rectangle, command);
            rectangles.Add(rectangle);
        }

        public void SetZeroXVelocityCommand(ICommand command)
        {
            zeroXVelocity = command;
        }

        public void SetZeroYVelocityCommand(ICommand command)
        {
            zeroYVelocity = command;
        }

        public void Update()
        {
            // Mouse.GetState().
            state = Mouse.GetState();

            // Branches like these will be avoided in the future. Will also check to make sure a rectangle exists before calling it, otherwise program will crash.
            if (state.LeftButton == ButtonState.Pressed)
            {
                
                if (rectangles[0].Contains(state.Position))
                {
                    mouseMappings[rectangles[0]].Execute();
                } else if (rectangles[1].Contains(state.Position))
                {
                    mouseMappings[rectangles[1]].Execute();
                }
                else if (rectangles[2].Contains(state.Position))
                {
                    mouseMappings[rectangles[2]].Execute();
                }
                else if (rectangles[3].Contains(state.Position))
                {
                    mouseMappings[rectangles[3]].Execute();
                }
            }
            if (state.RightButton == ButtonState.Pressed)
            {
                new Quit(gameHere).Execute();
            }
        }

    }
}
