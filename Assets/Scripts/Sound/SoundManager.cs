using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Sliders")]
    [SerializeField] private Slider geralSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private SoundList[] clips;

    private float geralVolume;
    private float sfxVolume;
    private float musicVolume;

    private List<SoundList> sfxSounds = new List<SoundList>();
    private List<SoundList> musicSounds = new List<SoundList>();

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("geralvolume"))
        {
            geralSlider.value = PlayerPrefs.GetFloat("geralvolume");
            musicSlider.value = PlayerPrefs.GetFloat("musicvolume");
            sfxSlider.value = PlayerPrefs.GetFloat("sfxvolume");
        }
        else
        {
            geralSlider.value = 1f;
            musicSlider.value = 1f;
            sfxSlider.value = 1f;
        }

        foreach (var clip in clips)
        {
            foreach (var sound in clip.clips)
            {
                clip.audioSources.Add(gameObject.AddComponent<AudioSource>());

                float specificVolume;
                if (clip.isMusic)
                {
                    specificVolume = musicVolume;
                    musicSounds.Add(clip);
                }
                else
                {
                    specificVolume = sfxVolume;
                    sfxSounds.Add(clip);
                }

                clip.audioSources[clip.audioSources.Count - 1].clip = sound;
                clip.audioSources[clip.audioSources.Count - 1].volume = clip.volume * geralVolume * specificVolume;
                clip.audioSources[clip.audioSources.Count - 1].pitch = clip.pitch;
            }
        }
    }

    public float PlayClip(string clipName)
    {
        SoundList s = Array.Find(clips, clip => clip.name == clipName);

        int randIndex = UnityEngine.Random.Range(0, s.audioSources.Count);
        s.audioSources[randIndex].Play();

        return s.audioSources[randIndex].clip.length;
    }

    public void ChangeGeralVolume(float newValue)
    {
        PlayerPrefs.SetFloat("geralvolume", newValue);
        geralVolume = newValue;

        foreach (var clip in musicSounds)
        {
            for (int i = 0; i < clip.audioSources.Count; i++)
            {
                clip.audioSources[i].volume = clip.volume * geralVolume * musicVolume;
            }
        }

        foreach (var clip in sfxSounds)
        {
            for (int i = 0; i < clip.audioSources.Count; i++)
            {
                clip.audioSources[i].volume = clip.volume * geralVolume * sfxVolume;
            }
        }
    }

    public void ChangeMusicVolume(float newValue)
    {
        PlayerPrefs.SetFloat("musicvolume", newValue);
        musicVolume = newValue;

        foreach (var clip in musicSounds)
        {
            for (int i = 0; i < clip.audioSources.Count; i++)
            {
                clip.audioSources[i].volume = clip.volume * geralVolume * musicVolume;
            }
        }
    }

    public void ChangeSFXVolume(float newValue)
    {
        PlayerPrefs.SetFloat("sfxvolume", newValue);
        sfxVolume = newValue;

        foreach (var clip in sfxSounds)
        {
            for (int i = 0; i < clip.audioSources.Count; i++)
            {
                clip.audioSources[i].volume = clip.volume * geralVolume * sfxVolume;
            }
        }
    }
}
