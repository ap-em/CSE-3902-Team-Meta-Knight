using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CStar : ICommand
    {

        IMario Mario;
        public CStar(IMario mario, Rectangle rect)
        {
            Mario = mario;
        }
        public void Execute()
        {
            Mario.StarPower();
        }
    }
}
