using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Audio;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] int selectedSubmenu;
    [SerializeField] GameObject[] submenus;

    //Graphics
    Resolution[] resolutionArray;
    [SerializeField] TMP_Dropdown resolutionDropdown;

    //Audio
    [SerializeField] AudioMixer mainAudioMixer;
    [SerializeField] TMP_Text musicPercentageLabel;
    [SerializeField] TMP_Text soundPercentageLabel;

    //Controls


    //Advanced
    [SerializeField] TMP_Dropdown localizationDropdown;

    void Start()
    {
        //Resolution
        resolutionDropdown.ClearOptions();
        resolutionArray = Screen.resolutions;
        List<string> resolutionOptions = new List<string>();
        int currentIndex = 0;
        for (int i = 0; i < resolutionArray.Length; i++)
        {
            string resolutionOption = resolutionArray[i].width + " x " + resolutionArray[i].height;
            resolutionOptions.Add(resolutionOption);
            if (resolutionArray[i].width == Screen.currentResolution.width && resolutionArray[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();

        // Localization Dropdown
        StartCoroutine(GenerateLocaleDropdownOptions());
    }

    void FixedUpdate()
    {
        if (selectedSubmenu == 0)
        {
            submenus[0].SetActive(true);
            submenus[1].SetActive(false);
            submenus[2].SetActive(false);
            submenus[3].SetActive(false);
        }
        else if (selectedSubmenu == 1)
        {
            submenus[0].SetActive(false);
            submenus[1].SetActive(true);
            submenus[2].SetActive(false);
            submenus[3].SetActive(false);
        }
        else if (selectedSubmenu == 2)
        {
            submenus[0].SetActive(false);
            submenus[1].SetActive(false);
            submenus[2].SetActive(true);
            submenus[3].SetActive(false);
        }
        else if (selectedSubmenu == 3)
        {
            submenus[0].SetActive(false);
            submenus[1].SetActive(false);
            submenus[2].SetActive(false);
            submenus[3].SetActive(true);
        }
        else
        {
            Debug.Log("selectedSubmenu : " + selectedSubmenu + " > 3");
        }
    }

    IEnumerator GenerateLocaleDropdownOptions()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        var options = new List<TMP_Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new TMP_Dropdown.OptionData(locale.name));
        }

        localizationDropdown.options = options;
        localizationDropdown.value = selected;
    }

    public void SetSelectedSubmenu(int selectedSubmenuIndex)
    {
        selectedSubmenu = selectedSubmenuIndex;
    }

    public void SetVerticalSync(bool useVerticalSync)
    {
        int boolToInt(bool b)
        {
            return b ? 1 : 0;
        }

        QualitySettings.vSyncCount = boolToInt(useVerticalSync);
    }

    public void SetAntiAliasing(bool useAntiAliasing)
    {
        int boolToInt(bool b)
        {
            return b ? 2 : 0;
        }

        QualitySettings.antiAliasing = boolToInt(useAntiAliasing);
    }

    public void SetShadows(bool useShadows)
    {
        ShadowQuality boolToShadowQuality(bool b)
        {
            return b ? ShadowQuality.All : ShadowQuality.Disable;
        }

        QualitySettings.shadows = boolToShadowQuality(useShadows);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionArray[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume(float volume)
    {
        mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        musicPercentageLabel.text = (volume * 100).ToString("F0") + "%";
    }

    public void SetSoundVolume(float volume)
    {
        mainAudioMixer.SetFloat("SoundVolume", Mathf.Log10(volume) * 20);
        soundPercentageLabel.text = (volume * 100).ToString("F0") + "%";
    }

    public void SetLocalization(int languageIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }
}
