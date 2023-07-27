using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IEventObserver
{
	[SerializeField]
	private Text _text;

    private int _currentScore;

    public static ScoreView Instance { get; private set; }

    public int CurrentScore
    {
        get => _currentScore;
        private set
        {
            _currentScore = value;
            _text.text = "Score: " + _currentScore.ToString();
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
    }

    private void OnDestroy()
    {
        EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
    }

    public void Reset()
    {
        CurrentScore = 0;
    }

    public void Process(EventData eventData)
    {
        if(eventData.EventId != EventIds.ShipDestroyed)
        {
            return;
        }

        ShipDestroyedEventData shipDestroyedEventData = (ShipDestroyedEventData)eventData;
        AddScore(shipDestroyedEventData.Team, shipDestroyedEventData.ScoreToAdd);
    }

    private void AddScore(Teams team, int scoreToAdd)
    {
        if(team != Teams.Enemy)
        {
            return;
        }

        CurrentScore += scoreToAdd;
    }
}

