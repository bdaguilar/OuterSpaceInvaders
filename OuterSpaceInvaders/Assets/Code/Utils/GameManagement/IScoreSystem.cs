public interface IScoreSystem
{
    int[] GetBestScores();
    void Reset();
    int CurrentScore { get; }
}

