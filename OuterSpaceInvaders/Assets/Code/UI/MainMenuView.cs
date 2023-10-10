using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, MainMenuMediator
{
	[SerializeField]
	private Button _startGameButton;
    [SerializeField]
    private Button _showLeaderboardButton;
    [SerializeField]
    private LeaderboardView _leaderboard;

    private void Awake()
    {
        _startGameButton.onClick.AddListener(OnStartButtonPressed);
        _showLeaderboardButton.onClick.AddListener(OnShowLeaderboardButtonPressed);
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