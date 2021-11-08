using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Interfaces
{
    public interface IFlag
    {
        /*Triggers the win screen and provides point amount depending on how high up mario is*/
        public void Win(IMario mario);
    }
}
