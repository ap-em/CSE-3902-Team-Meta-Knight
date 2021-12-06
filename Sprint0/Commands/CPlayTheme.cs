using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    
    class CPlayTheme : ICommand
    {
        Rectangle rectangle;
        IMario mario;
        IThemeBox block;
        public CPlayTheme(IThemeBox block, IMario mario, Rectangle rectangle)
        {
            this.mario = mario;
            this.rectangle = rectangle;

            this.block= block;

        }

        public void Execute()
        {
            Debug.WriteLine("death");
            block.PlayTheme(mario);
        }
    }
}
