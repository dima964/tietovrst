using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] TMP_Text leaderboardText;
    ScoreApi scoreApi;

    void Start()
    {
        scoreApi = GetComponent<ScoreApi>();
    }

    public void GetLeaderboard()
    {
        StartCoroutine(scoreApi.GetTopScores(ShowScores));
    }

    void ShowScores(int[] scores)
    {
        string result = "Top 5 scores:\n";
        for (int i = 0; i < scores.Length; i++)
        {
            result += (i + 1) + ". " + scores[i] + "\n";
        }
        leaderboardText.text = result;
    }
}