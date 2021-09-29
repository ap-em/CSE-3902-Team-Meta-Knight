using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Interfaces
{
   public interface IProjectile
    {
        void Update();
        void Draw();
        void Move();
        int GetFuseTime();
    }
}
