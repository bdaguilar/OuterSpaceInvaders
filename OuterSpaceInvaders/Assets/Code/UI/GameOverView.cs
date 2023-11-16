using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverView : BaseInGameView
{
	[SerializeField]
	private TextMeshProUGUI _scoreText;
	[SerializeField]
	private Button _restartButton;
    [SerializeField]
    private Button _returnToMenuButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartPressed);
        _returnToMenuButton.onClick.AddListener(OnBackToMainMenuPressed);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        IScoreSystem scoreSystem = ServiceLocator.Instance.GetService<IScoreSystem>();
        _scoreText.SetText(scoreSystem.CurrentScore.ToString());
        gameObject.SetActive(true);
    }
}
