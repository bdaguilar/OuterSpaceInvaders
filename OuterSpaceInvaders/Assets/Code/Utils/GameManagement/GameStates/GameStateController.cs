using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField]
    private GameFacade _gameFacade;

    private IGameState _currentState;

    private Dictionary<GameStates, IGameState> _idToState;

    private void Awake()
    {
        _idToState = new Dictionary<GameStates, IGameState>
                    {
                        {GameStates.Playing, new PlayingState()},
                        {GameStates.Victory, new VictoryState(_gameFacade)},
                        {GameStates.GameOver, new GameOverState(_gameFacade)},
                    };
    }

    private void Start()
    {
        _currentState = GetState(GameStates.Playing);
        _currentState.Start(OnStateEndedCallback);
    }

    private async void OnStateEndedCallback(GameStates nextState)
    {
        await Task.Yield();
        _currentState.Stop();
        _currentState = GetState(nextState);
        _currentState.Start(OnStateEndedCallback);
    }

    public void Reset()
    {
        OnStateEndedCallback(GameStates.Playing);
    }

    private IGameState GetState(GameStates gameState)
    {
        return _idToState[gameState];
    }
}

