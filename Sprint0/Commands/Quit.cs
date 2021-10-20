using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
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
    class Quit:ICommand
    {

        public Quit(IMario mario)
        {
            
        }
        public void Execute()
        {
            Game0.Instance.Exit();
        }
    }
}
