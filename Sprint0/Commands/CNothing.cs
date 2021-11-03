using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CNothing : ICommand
    {

        public CNothing(IGameObject go, Rectangle rectangle)
        {

        }
        public void Execute()
        {

        }
    }
}
