using System;

public class ScoreSystem : IScoreSystem
{

    private int _currentScore;

    public int Score => _currentScore;

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
