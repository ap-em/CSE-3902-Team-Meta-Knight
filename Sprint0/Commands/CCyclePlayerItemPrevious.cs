using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel Cse 3902*/
    class CCyclePlayerItemPrevious : ICommand
    {
        IItems item;
        public CCyclePlayerItemPrevious(IItems item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.PrevItem();
        }
    }
}
