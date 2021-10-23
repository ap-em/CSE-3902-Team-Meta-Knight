using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0
{
    public interface IMarioState
    {
        string ID { get; }
        public void MoveLeft();
        public void MoveRight();
        public void StopMovingHorizontal();
        public void StopMovingVertical();
        public void Jump();
        public void Attack();
        public void Crouch();
        public void Update();
        public void UpBounce(Rectangle rectangle);

        public void DownBounce(Rectangle rectangle);

        public void RightBounce(Rectangle rectangle);

        public void LeftBounce(Rectangle rectangle);

    }
}
