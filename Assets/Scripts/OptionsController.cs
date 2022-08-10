using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float DefaultVolume=0.7f;
    [SerializeField] float DefaultDifficulty = 2f;
    [SerializeField] Slider difficultySlider;
    private AudioPlayer audioPlayer;
    void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChange);
        difficultySlider.onValueChanged.AddListener(OnDifficultySliderChange);
    }
    
    private void OnVolumeSliderChange(float value)
    {
        audioPlayer.SetVolume(value);
    }
    private void OnDifficultySliderChange(float value)
    {
        PlayerPrefsController.SetDifficulty(value);
    }

    public void SetDefault()
    {
        volumeSlider.value= DefaultVolume;
        difficultySlider.value = DefaultDifficulty;
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoad>().LoadStartMenu();
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderChange);
        difficultySlider.onValueChanged.RemoveListener(OnDifficultySliderChange);
    }
}
