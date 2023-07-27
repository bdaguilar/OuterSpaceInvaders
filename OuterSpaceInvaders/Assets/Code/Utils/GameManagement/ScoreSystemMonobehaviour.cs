using UnityEngine;

public class ScoreSystemMonobehaviour : MonoBehaviour
{
    private static ScoreSystemMonobehaviour _instance;
    private int _currentScore;

    public static ScoreSystemMonobehaviour Instance()
    {
        if(_instance == null)
        {
            GameObject gameObject = new GameObject();
            _instance = gameObject.AddComponent<ScoreSystemMonobehaviour>();
        }

        return _instance;
    }

    public int GetScore()
    {
        return _currentScore;
    }

    public void AddScore(Teams team, int scoreToAdd)
    {
        _currentScore += scoreToAdd;
    }
}

