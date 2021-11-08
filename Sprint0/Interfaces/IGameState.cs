using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Interfaces
{
    public enum GameStates {Pause, GameOver, Win }
    public interface IGameState
    {
        GameStates Type { get; }
        void Proceed();
        void Pause();
        void GameOver();

    }
}
