using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defalutVolume = 0.5f;
    [SerializeField] float defalutDifficulty = 1;
    [SerializeField] Slider difficultySlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerRefController.GetGameVolume();
        difficultySlider.value = PlayerRefController.GetGameDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerRefController.SetGameVolume(volumeSlider.value);
        PlayerRefController.SetGameDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().BackToMainMenu();
    }

    public void SetDefaluts()
    {
        volumeSlider.value = defalutVolume;
        difficultySlider.value = defalutDifficulty;
    }
}
