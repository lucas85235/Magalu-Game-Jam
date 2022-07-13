using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayClip("Music");
    }
}
