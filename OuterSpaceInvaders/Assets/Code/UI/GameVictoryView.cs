using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameVictoryView : BaseInGameView
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
        ScoreView scoreView = ServiceLocator.Instance.GetService<IScoreSystem>() as ScoreView;
        _scoreText.SetText(scoreView.CurrentScore.ToString());
        gameObject.SetActive(true);
    }
}

