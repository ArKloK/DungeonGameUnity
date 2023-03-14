using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public Slider slider;
    private float sliderValue;
    public Image imagenMute;

    // Start is called before the first frame update
    void Start()
    {
        //**************Resolution Dropdown startup configuration***************
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);

        //***************Volume Slider startup configuration*******************
        slider.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider()
    {
        sliderValue = slider.value;
        PlayerPrefs.SetFloat("audioVolume", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void CheckMute()
    {
        if (sliderValue == 0)
            imagenMute.enabled = true;
        else
            imagenMute.enabled = false;
    }

}
