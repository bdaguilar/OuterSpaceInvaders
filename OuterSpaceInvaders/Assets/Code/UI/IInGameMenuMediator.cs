using System;

public interface IInGameMenuMediator
{
    void OnBackToMenuPressed();
    void OnRestartGamePressed();
    void OnResumeGamePressed();
    void OnPauseGamePressed();
}
