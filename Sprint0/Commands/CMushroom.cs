using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CMushroom : ICommand
    {

        IMario Mario;
        public CMushroom(IMario mario, Rectangle rect)
        {
            Mario = mario;
        }
        public void Execute()
        {
            Mario.MushroomPower();
        }
    }
}
