using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, MainMenuMediator
{
	[SerializeField]
	private Button _startGameButton;
    [SerializeField]
    private Button _showLeaderboardButton;
    [SerializeField]
    private Button _quitButton;
    [SerializeField]
    private LeaderboardView _leaderboard;

    private void Awake()
    {
        _startGameButton.onClick.AddListener(OnStartButtonPressed);
        _showLeaderboardButton.onClick.AddListener(OnShowLeaderboardButtonPressed);
        _quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    private void OnQuitButtonPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Start()
    {
        _leaderboard.Configure(this);
        _leaderboard.Hide();
    }

    private void OnStartButtonPressed()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadGameSceneCommand());
    }

    private void OnShowLeaderboardButtonPressed()
    {
        _leaderboard.Show();
    }

    public void OnCloseLeadorboardButtonPressed()
    {
        _leaderboard.Hide();
    }
}