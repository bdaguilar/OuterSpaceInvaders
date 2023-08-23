using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuView : MonoBehaviour, IEventObserver, IInGameMenuMediator
{
    [SerializeField]
    private Button _pauseBattleButton;
    [SerializeField]
    private PauseView _pauseView;
    [SerializeField]
    private GameVictoryView _gameVictoryView;
    [SerializeField]
    private GameOverView _gameOverView;

    private CommandQueue _commandQueue;

    private void Awake()
    {
        _pauseBattleButton.onClick.AddListener(OnPauseGamePressed);
        _pauseView.Configure(this);
        _gameOverView.Configure(this);
        _gameVictoryView.Configure(this);
    }

    private void Start()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.GameOver, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
        _commandQueue = ServiceLocator.Instance.GetService<CommandQueue>();
    }

    private void HideAllViews()
    {
        _pauseView.Hide();
        _gameOverView.Hide();
        _gameVictoryView.Hide();
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.GameOver, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.Victory, this);
    }

    public void OnBackToMenuPressed()
    {
        _commandQueue.AddCommand(new LoadSceneCommand("MenuScene"));
        HideAllViews();
    }

    public void OnPauseGamePressed()
    {
        _commandQueue.AddCommand(new PauseGameCommand());
        _pauseView.Show();
    }

    public void OnRestartGamePressed()
    {
        HideAllViews();
        _commandQueue.AddCommand(new RestartGameCommand());
    }

    public void OnResumeGamePressed()
    {
        _commandQueue.AddCommand(new ResumeGameCommand());
        _pauseView.Hide();
    }

    public void Process(EventData eventData)
    {
        if(eventData.EventId == EventIds.Victory)
        {
            _gameVictoryView.Show();
        }

        if (eventData.EventId == EventIds.GameOver)
        {
            _gameOverView.Show();
        }
    }
}

