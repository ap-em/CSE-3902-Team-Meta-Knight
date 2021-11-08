using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CTriggerFlag:ICommand
    {
        IMario mario;
        IFlag flag;

        public CTriggerFlag(IFlag flag,IMario mario)
        {
            this.mario = mario;
            this.flag = flag;

        }

        public void Execute()
        {
            flag.Win(mario);
        }
    }
}
