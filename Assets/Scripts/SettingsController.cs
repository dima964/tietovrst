using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown jumpKeyInput;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Dropdown graphicsInput;
    [SerializeField] Slider sensitivitySlider;

    void Start()
    {
        jumpKeyInput.value = PlayerPrefs.GetInt("JumpKey", 0);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        graphicsInput.value = PlayerPrefs.GetInt("Graphics", 1); // Medium
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("JumpKey", jumpKeyInput.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetInt("Graphics", graphicsInput.value);
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.Save();
    }
    public void ResetSettings()
    {
        PlayerPrefs.DeleteAll();

        // Reset to defaults
        jumpKeyInput.value = 0;       // Space
        volumeSlider.value = 0.5f;
        graphicsInput.value = 1;       // Medium
        sensitivitySlider.value = 1.0f;

        // Apply defaults live
        AudioListener.volume = 0.5f;
        QualitySettings.SetQualityLevel(1);
    }
}