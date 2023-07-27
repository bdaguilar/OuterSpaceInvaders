using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameOverView : MonoBehaviour, IEventObserver
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
        EventQueue.Instance.Subscribe(EventIds.GameOver, this);
    }

    private void OnDestroy()
    {
        EventQueue.Instance.Unsubscribe(EventIds.GameOver, this);
    }

    public void RestartGame()
    {
        _gameFacade.StartBattle();
        gameObject.SetActive(false);
    }

    public void Process(EventData eventData)
    {
        if (eventData.EventId != EventIds.GameOver)
        {
            return;
        }

        ProcessShipGameOver();
    }

    private void ProcessShipGameOver()
    {
        _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
        gameObject.SetActive(true);
    }
}
