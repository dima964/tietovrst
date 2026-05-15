using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player vastaa pelaajan toiminnasta (liikkuminen, hyökkäys).
/// </summary>
public class Player : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        // TODO: hae Health-komponentti
        health = GetComponent<Health>();
    }

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError("Health-komponentti puuttuu");
        }

        TakeDamage(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
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
        File.WriteAllText($"{Application.dataPath}/playerData.json", json);
    }

}

