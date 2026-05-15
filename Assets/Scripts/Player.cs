using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player vastaa pelaajan toiminnasta (liikkuminen, hyökkäys).
/// </summary>
public class Player : MonoBehaviour
{
    Health health;
    public int score = 0;

    void Awake()
    {
        // TODO: hae Health-komponentti
        health = GetComponent<Health>();
    }

    private void Start()
    {
        
        Load();
        if (health == null)
        {
            Debug.LogError("Health-komponentti puuttuu");
        }

        TakeDamage(1);
    }

    private void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            Save();
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            TakeDamage(1);
        }

        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            Heal(1);
        }
    }

    public void TakeDamage(int amount)
    {
        // TODO: vähennä elämää Healthin kautta
        health.Modify(-amount);
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
    }
    public void Save()
    {
        UnityEngine.Debug.Log("Testi: JSON-tallennus käynnissä");
        PlayerData playerData = new PlayerData(this);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText($"{UnityEngine.Application.dataPath}/playerData.json", json);
    }
    public void Load()
    {
        string path = UnityEngine.Application.dataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            health.CurrentHealth = data.health;
            score = data.score;
            UpdateScoreUI();
        }
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + score;
        }
    }
    [SerializeField] TMPro.TMP_Text scoreText;

}

