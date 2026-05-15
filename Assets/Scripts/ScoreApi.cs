using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreApi : MonoBehaviour
{
    private string serverUrl = "http://localhost:5274";

    public IEnumerator GetTopScores(System.Action<int[]> callback)
    {
        using (UnityWebRequest req =
            UnityWebRequest.Get(serverUrl + "/scores"))
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                string json = "{\"scores\":" + req.downloadHandler.text + "}";
                ScoreList list = JsonUtility.FromJson<ScoreList>(json);
                callback(list.scores.ToArray());
            }
            else
            {
                UnityEngine.Debug.LogError("Error: " + req.error);
            }
        }
    }

    public IEnumerator PostScore(int score)
    {
        using (UnityWebRequest req =
            UnityWebRequest.PostWwwForm(serverUrl + "/scores/" + score, ""))
        {
            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
                UnityEngine.Debug.LogError("Post error: " + req.error);
        }
    }
}