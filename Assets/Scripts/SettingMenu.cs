using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    [SerializeField]public Slider slider;
    [SerializeField]public AudioMixer audioMixer;

    private void Awake()
    {
        audioMixer.SetFloat("volume", -30f);
        slider.value = GetMasterValue();
    }

    public float GetMasterValue()
    {
        float value;
        bool result = audioMixer.GetFloat("volume", out value);
        if (result)
        {
            return value;
        } else
        {
            return 0f;
        }
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }



}
