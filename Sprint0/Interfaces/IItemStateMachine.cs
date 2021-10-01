using System;
using System.Collections.Generic;
using System.Text;

/*
 * Alexander Clayton CSE 3902 09/15/2021
 * Modified by Owen Tishenkel CSE 3902 10/1/2021
 */
namespace Sprint0.Interfaces
{
   public interface IItemStateMachine
    {
        void Update();
        void PrevItem();
        void NextItem();
    }
}
