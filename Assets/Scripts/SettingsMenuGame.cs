using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsMenuGame : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private float sliderValueVolume;
    public Slider sliderVolume;
    public Image imageMute;

    public Slider sliderBrightness;
    private float sliderValueBrightness;
    public Image brightnessPanel;

    public Toggle toggle;

    // Start is called before the first frame update
    public void Start()
    {
        //**************Resolution Dropdown startup configuration***************
        CheckResolution();

        //***************Volume Slider startup configuration*******************
        sliderVolume.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = sliderVolume.value;
        CheckMute();

        //***************Brightness Slider startup configuration*******************
        sliderBrightness.value = PlayerPrefs.GetFloat("brightness", 0.35f);

        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, sliderBrightness.value);

        //***************Full Screen Toggle startup configuration*******************
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    public void ChangeSliderVolume()
    {
        Debug.Log("CAMBIANDO VOLUMEN");
        sliderValueVolume = sliderVolume.value;
        PlayerPrefs.SetFloat("audioVolume", sliderValueVolume);
        AudioListener.volume = sliderVolume.value;
        CheckMute();
    }

    public void ChangeSliderBrightness()
    {
        Debug.Log("CAMBIANDO BRILLO");
        sliderValueBrightness = sliderBrightness.value;
        PlayerPrefs.SetFloat("brightness", sliderValueBrightness);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, sliderBrightness.value);
    }

    public void CheckMute()
    {
        if (sliderValueVolume == 0)
            imageMute.enabled = true;
        else
            imageMute.enabled = false;
    }

    public void ActivateFullScreen()
    {
        Screen.fullScreen = toggle.isOn;
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                actualResolution = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = actualResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void ChangeResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
