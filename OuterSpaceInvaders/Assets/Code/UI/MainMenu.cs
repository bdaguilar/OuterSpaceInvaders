using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private Button _startGameButton;

    private void Awake()
    {
        _startGameButton.onClick.AddListener(OnStartButtonPressed);
    }

    private void OnStartButtonPressed()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadGameSceneCommand());
    }
}