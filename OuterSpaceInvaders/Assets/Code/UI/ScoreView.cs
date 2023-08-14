using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IEventObserver, IScoreSystem
{
	[SerializeField]
	private Text _text;

    private int _currentScore;

    public int CurrentScore
    {
        get => _currentScore;
        private set
        {
            _currentScore = value;
            _text.text = "Score: " + _currentScore.ToString();
        }
    }

    private void Start()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipDestroyed, this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
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

    public void AddScore(Teams team, int scoreToAdd)
    {
        if(team != Teams.Enemy)
        {
            return;
        }

        CurrentScore += scoreToAdd;
    }
}

