using System;

public class ScoreSystem
{
	private static ScoreSystem _instance;

    private int _currentScore;

    public static ScoreSystem Instance => _instance ?? (_instance = new ScoreSystem());
    public int Score => _currentScore;

    private ScoreSystem()
	{

	}

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
