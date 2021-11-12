using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Interfaces
{
    interface IKillBox
    {
        void Kill(IMario mario);
        void Kill(IEnemy enemy);
    }
}
