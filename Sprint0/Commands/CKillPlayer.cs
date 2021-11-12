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
    
    class CKillPlayer : ICommand
    {
        Rectangle rectangle;
        IMario mario;
        IKillBox killBox;
        public CKillPlayer(IMario mario, IKillBox killBox, Rectangle rectangle)
        {
            this.mario = mario;
            this.rectangle = rectangle;

            this.killBox = killBox;
            
    }

        public void Execute()
        {
            Debug.WriteLine("death");
            killBox.Kill(mario);        }
    }
}
