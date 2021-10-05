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
    public interface ILinkState
    {
        string ID { get; }
        public void MoveLeft();
        public void MoveRight();
        public void MoveUp();
        public void MoveDown();
        public void StopMoving(string sourceDirection);
        public void Jump();
        public void Attack();
        public void Crouch();
        public void Update();
    }
}
