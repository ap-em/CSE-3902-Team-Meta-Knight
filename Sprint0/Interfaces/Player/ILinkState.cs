using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface ILinkState
    {
        string ID { get; }
        public void MoveLeft();
        public void MoveRight();
        public void MoveUp();
        public void MoveDown();
        public void StopMoving();
        public void Jump();
        public void Attack();
        public void Crouch();
        public void Update();
    }
}
