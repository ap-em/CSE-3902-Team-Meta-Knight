using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands
{
    class CNothing : ICommand
    {

        public CNothing(IGameObject go,IGameObject collided, Rectangle rectangle)
        {

        }
        public void Execute()
        {

        }
    }
}
