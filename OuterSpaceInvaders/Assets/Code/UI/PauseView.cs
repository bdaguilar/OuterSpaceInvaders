using UnityEngine;
using UnityEngine.UI;

public class PauseView : BaseInGameView
{
    [SerializeField]
    private Button _resumeBattleButton;
    [SerializeField]
    private Button _restartBattleButton;
    [SerializeField]
    private Button _stopBattleButton;


    private void Awake()
    {
        _resumeBattleButton.onClick.AddListener(OnResumePressed);
        _restartBattleButton.onClick.AddListener(OnRestartPressed);
        _stopBattleButton.onClick.AddListener(OnBackToMainMenuPressed);
        gameObject.SetActive(false);
    }

    private void OnResumePressed()
    {
        _mediator.OnResumeGamePressed();
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}