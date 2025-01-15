using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.Audio;
public class SettingMenu : MonoBehaviour
{
    public TMP_Dropdown ResolutionDropdown;
    public TMP_Dropdown QualityDropdown;
    public Slider Master;
    public AudioMixer MainAudioMixer;
     
    public void ChangeMasterVolume()
    {
        MainAudioMixer.SetFloat("Master",Master.value);
    }

    Resolution[] resolutions;
    void Start()
    {
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>(); 
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
                currentResolutionIndex = i;
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.RefreshShownValue();
        LoadSetting(currentResolutionIndex);

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", QualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", ResolutionDropdown.value);
    }

    public void LoadSetting(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            QualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        else 
            QualityDropdown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            ResolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            ResolutionDropdown.value = currentResolutionIndex;

    }
 
}
