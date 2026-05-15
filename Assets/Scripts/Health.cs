using UnityEngine;

/// <summary>
/// Health vastaa vain el‰m‰n m‰‰r‰st‰.
/// </summary>
public class Health : MonoBehaviour
{
    // maksimi el‰m‰, voi vaihtaa editorin kautta
    [SerializeField] private int maxHealth = 100;

    // t‰m‰nhetkinen el‰m‰
    private int currentHealth;
    public int CurrentHealth { get => currentHealth; }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// positiivinen arvo --> parantaa
    /// negatiivinen arvo --> tekee vahinkoa
    /// </summary>
    public void Modify(int amount)
    {
        // Kasvattaa terveytt‰
        currentHealth += amount;

        // Mathf.Clamp est‰‰ arvon menemisen alle 0 tai yli maksimin
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Testitulostus
        Debug.Log("Health: " + currentHealth);
    }

}
