using UnityEngine;

public abstract class BaseInGameView : MonoBehaviour
{
    protected IInGameMenuMediator _mediator;

    public void Configure(IInGameMenuMediator mediator)
    {
        _mediator = mediator;
    }

    protected void OnRestartPressed()
    {
        _mediator.OnRestartGamePressed();
    }

    protected void OnBackToMainMenuPressed()
    {
        _mediator.OnBackToMenuPressed();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public abstract void Show();
}