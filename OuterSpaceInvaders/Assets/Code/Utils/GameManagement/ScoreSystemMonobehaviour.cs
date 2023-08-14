using UnityEngine;

public class ScoreSystemMonobehaviour : MonoBehaviour, IScoreSystem
{
    private int _currentScore;

    public int GetScore()
    {
        return _currentScore;
    }

    public void AddScore(Teams team, int scoreToAdd)
    {
        _currentScore += scoreToAdd;
    }

    public void Reset()
    {
        _currentScore = 0;
    }
}

