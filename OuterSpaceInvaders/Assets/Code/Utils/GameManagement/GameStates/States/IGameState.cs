using System;
using UnityEngine;

public interface IGameState
{
    void Start(Action<GameStates> onStateEndedCallback);
    void Stop();
}

