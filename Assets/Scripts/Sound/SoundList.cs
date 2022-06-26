using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundList
{
    public string name;

    public List<AudioClip> clips;

    [Range(0, 1)]
    public float volume;

    [Range(0, 1)]
    public float pitch;

    public bool isMusic;

    [HideInInspector]
    public List<AudioSource> audioSources;
}
