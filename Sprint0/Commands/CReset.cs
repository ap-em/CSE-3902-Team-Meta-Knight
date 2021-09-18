using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CReset : ICommand
    {
        /*Commands that must be executed in order to reset the state of the game, 
         * preferably in the order they need to be executed.*/
        private List<ICommand> resetCommands;
        

        public CReset(List<ICommand>resetCommands)
        {
            this.resetCommands = resetCommands;
        }

        public void Execute()
        {
            for(int index=0; index<resetCommands.Count; index++)
            {
                resetCommands[index].Execute();
            }
        }
    }
}
