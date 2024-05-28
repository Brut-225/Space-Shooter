using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int score)
    {
        Score += score;
        UpdateScore();
    }

    public void ResetScore()
    {
        Score = 0;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score: {Score}";
    }
}