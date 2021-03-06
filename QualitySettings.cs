using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
public class QualitySettings : MonoBehaviour
{
    //public variables 
    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;
    public RenderPipelineAsset[] qualityLevels;
    public TMP_Dropdown dropdown;
    public TMP_Dropdown texture_dropdown;
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown difficulty_dropdown;
    public TMP_Dropdown languages_dropdown;
    public TMP_Dropdown Antialiasing_Dropdown;
    public float difficulty;
    public static RenderPipelineAsset renderPipeline;
    private static readonly string[] names;
    private static int masterTextureLimit;
    private static int antiAliasing;


    // Start is called before the first frame update
    private void Start()
    {
        dropdown.value = QualitySettings.GetQualityLevel();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    //creating settexturequality method
    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.masterTextureLimit = textureIndex;
        dropdown.value = 6;

    }
    // creating getquality method 
    private static int GetQualityLevel()
    {
        throw new NotImplementedException();
    }
    //creating set resolution method 
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
    //creating setfullscreen method 
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

    }
    //creating setvolume method
    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("Volume", Volume);

    }
    //creating setmaingame volumemethod
    public void SetmaingameVolume(float Volume)
    {
        audioMixer2.SetFloat("Volumem", Volume);

    }
    //creating antialiasing method
    public void SetAntiAliasing(int aaindex)
    {
        QualitySettings.antiAliasing = aaindex;
        dropdown.value = 6;
    }
    //creating changelevel method
    public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = qualityLevels[value];
    }
    //creating setqualitylevel method 
    private static void SetQualityLevel(int value)
    {
        throw new NotImplementedException();
    }
    //creating setdifficulty method 
    public void SetDifficulty()
    {
        if (difficulty_dropdown.value == 0)
        {
            difficulty = 0.5f;
        }
        if (difficulty_dropdown.value == 1)
        {
            difficulty = 1f;
        }
        if (difficulty_dropdown.value == 2)
        {

            difficulty = 3f;
        }
        Debug.Log("Difficulty" + difficulty);
    }

    //creating setquality method
    public void SetQuality(int qualityIndex)
    {

        if (qualityIndex != 6)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        //   const int V = 0;
        switch (qualityIndex)
        {
            case 0:
                Antialiasing_Dropdown.value = 0;

                //                dropdown.value = V;
                texture_dropdown.value = 3;
                break;
            case 1:
                Antialiasing_Dropdown.value = 0;

                //              dropdown.value = 1;
                texture_dropdown.value = 2;
                break;
            case 2:
                Antialiasing_Dropdown.value = 0;

                //                dropdown.value = 2;
                texture_dropdown.value = 1;
                break;
            case 3:
                Antialiasing_Dropdown.value = 0;
                //                 dropdown.value = 3;
                texture_dropdown.value = 0;
                break;
            case 4:
                Antialiasing_Dropdown.value = 1;
                //                  dropdown.value = 4;
                texture_dropdown.value = 0;
                break;
            case 5:
                //                  dropdown.value = 5;
                Antialiasing_Dropdown.value = 2;
                texture_dropdown.value = 0;
                break;
        }
        dropdown.value = qualityIndex;
    }

    //save settings methods
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference",
                    dropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
                   Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("TextureQualityPreference",
               texture_dropdown.value);
        PlayerPrefs.SetInt("DifficultySettingPreference",
            difficulty_dropdown.value);
        PlayerPrefs.SetInt("LanguagesSettingsPreference",
            languages_dropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference",
     Antialiasing_Dropdown.value);

    }
    //load settings method
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            dropdown.value =
                         PlayerPrefs.GetInt("QualitySettingPreference");
        }
        else
        {
            dropdown.value = 3;
        }

        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.value =
                         PlayerPrefs.GetInt("ResolutionPreference");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }

        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            Screen.fullScreen =
            Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        }
        else
        {
            Screen.fullScreen = true;
        }

        if (PlayerPrefs.HasKey("TextureQualityPreference"))
        {
            texture_dropdown.value =
                         PlayerPrefs.GetInt("TextureQualityPreference");
        }
        else
        {
            texture_dropdown.value = 0;
        }

        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
        {
            Antialiasing_Dropdown.value =
                         PlayerPrefs.GetInt("AntiAliasingPreference");
        }
        else
        {
            Antialiasing_Dropdown.value = 1;
        }

        if (PlayerPrefs.HasKey("DifficultySettingPreference"))
        {
            difficulty_dropdown.value =
                         PlayerPrefs.GetInt("DifficultySettingPreference");
        }
        else
        {
            difficulty_dropdown.value = 0;
        }
    }
}
