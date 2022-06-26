using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClips : MonoBehaviour
{
    public AudioClip[] adClips;
    private int index;

    public float CurrentClipLegth => adClips[index].length;

    public void PlayClip()
    {  
        // Play current sound
        // I would rather use PlayOneShot in order to allow multiple concurrent sounds
        AudioSource.PlayClipAtPoint(adClips[index], transform.position);

        // Increase the index, wrap around if reached end of array
        index = (index + 1) % adClips.Length;
    }
}
