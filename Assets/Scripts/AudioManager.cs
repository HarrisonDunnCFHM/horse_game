using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //cached refs
    AudioSource myAudioSource;
    [Range(0f, 1f)] public float masterVolume;
    [Range(0f, 1f)] public float musicVolume;
    [Range(0f, 1f)] public float effectsVolume;
    public static bool sillyMode;

    //cached refs
    PopOutMenu correctMenu;
    Slider masterVolSlider;
    Slider effectsVolSlider;
    Slider musicVolSlider;
    Toggle sillyToggle;
    float mutedVol;

    private void Awake()
    {
        int numberOfManagers = FindObjectsOfType<AudioManager>().Length;
        if (numberOfManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        ResetSliders();
    }

    private void Update()
    {
        masterVolume = masterVolSlider.value;
        musicVolume = musicVolSlider.value;
        effectsVolume = effectsVolSlider.value;
        sillyMode = sillyToggle.isOn;
        myAudioSource.volume = musicVolume * masterVolume;
    }

   
    public void ResetSliders()
    {
        var menus = FindObjectsOfType<PopOutMenu>();
        foreach (PopOutMenu menu in menus)
        {
            if (menu.name == "Options Menu") { correctMenu = menu; }
        }
        var sliders = correctMenu.GetComponentsInChildren<Slider>();
        foreach (Slider slider in sliders)
        {
            if (slider.name == "Master Volume") { masterVolSlider = slider; }
            if (slider.name == "SFX Volume") { effectsVolSlider = slider; }
            if (slider.name == "Music Volume") { musicVolSlider = slider; }
        }
        var toggles = correctMenu.GetComponentsInChildren<Toggle>();
        foreach (Toggle toggle in toggles)
        {
            if(toggle.name == "Silly Mode Toggle") { sillyToggle = toggle; }
        }
        sillyToggle.isOn = sillyMode;
        masterVolSlider.value = masterVolume;
        effectsVolSlider.value = effectsVolume;
        musicVolSlider.value = musicVolume;
    }
}
