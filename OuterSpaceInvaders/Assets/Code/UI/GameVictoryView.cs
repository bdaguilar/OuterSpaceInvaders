using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameVictoryView : MonoBehaviour, IEventObserver
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _returnToMenuButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _returnToMenuButton.onClick.AddListener(OnReturnToMenuPressed);
    }

    private void Start()
    {
        gameObject.SetActive(false);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.Victory, this);
    }

    public void RestartGame()
    {
        ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
        gameObject.SetActive(false);
    }

    public void Process(EventData eventData)
    {
        if (eventData.EventId != EventIds.Victory)
        {
            return;
        }

        ScoreView scoreView = ServiceLocator.Instance.GetService<IScoreSystem>() as ScoreView;
        _scoreText.SetText(scoreView.CurrentScore.ToString());
        gameObject.SetActive(true);
    }

    private void OnReturnToMenuPressed()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("MenuScene"));
    }
}

