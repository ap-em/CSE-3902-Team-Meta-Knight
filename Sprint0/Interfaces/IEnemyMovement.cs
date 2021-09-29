using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces
{
    public interface IEnemyMovement
    {

        void Update();
        void Move();
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        String GetDirection();
        void SetXVelocity(int x);
        void SetYVelocity(int y);
        int GetXVelocity();
        int GetYVelocity();
    }
}
