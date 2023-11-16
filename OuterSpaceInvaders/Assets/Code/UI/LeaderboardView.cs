using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField]
    private Button _closeButton;
    [SerializeField]
    private RectTransform _container;
    [SerializeField]
    private ScoreEntryView _scoreEntryViewPrefab;
    [SerializeField]
    private List<ScoreEntryView> _scoreEntryViewInstances;

    private MainMenuMediator _mediator;

    private void Awake()
    {
        _closeButton.onClick.AddListener(OnCloseButtonPressed);
    }

    public void Configure(MainMenuMediator mediator)
    {
        _mediator = mediator;
    }

    private void OnCloseButtonPressed()
    {
        _mediator.OnCloseLeadorboardButtonPressed();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        int[] bestScores = ServiceLocator.Instance.GetService<IScoreSystem>().GetBestScores();
        for(int i = 0; i < bestScores.Length; i++)
        {
            int bestScore = bestScores[i];
            if(bestScore <= 0)
            {
                continue;
            }
            string position = (i + 1).ToString();
            string score = bestScore.ToString();
            _scoreEntryViewInstances[i].Configure(position, score);
            _scoreEntryViewInstances[i].gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        foreach(ScoreEntryView scoreEntryView in _scoreEntryViewInstances)
        {
            scoreEntryView.gameObject.SetActive(false);
        }
    }
}
