using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSilder;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1f;
    // Start is called before the first frame update
    void Start()
    {
        volumeSilder.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSilder.value);
        }
        else
        {
            Debug.LogWarning("No Music Player Found");
        }
       
      
    }

    public void SavdAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSilder.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<GameLoader>().LoadGameMenu();
    }

    public void SetDefaults()
    {
        volumeSilder.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}

