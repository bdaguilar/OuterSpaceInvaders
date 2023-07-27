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
    private GameFacade _gameFacade;

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void Start()
    {
        gameObject.SetActive(false);
        EventQueue.Instance.Subscribe(EventIds.Victory, this);
    }

    private void OnDestroy()
    {
        EventQueue.Instance.Unsubscribe(EventIds.Victory, this);
    }

    public void RestartGame()
    {
        _gameFacade.StartBattle();
        gameObject.SetActive(false);
    }

    public void Process(EventData eventData)
    {
        if (eventData.EventId != EventIds.Victory)
        {
            return;
        }

        _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
        gameObject.SetActive(true);
    }
}

