using UnityEngine;

public class ScoreSystemMonoWithSerializableFields : MonoBehaviour
{
    [SerializeField]
    private TextMesh _text;

    private static ScoreSystemMonoWithSerializableFields _instance;
    private int _currentScore;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public static ScoreSystemMonoWithSerializableFields Instance()
    {
        return _instance;
    }

    public void AddScore(Teams team, int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        _text.text = _currentScore.ToString();
    }

    public void Reset()
    {
        _currentScore = 0;
        _text.text = _currentScore.ToString();
    }
}