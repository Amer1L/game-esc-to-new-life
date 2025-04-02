using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    public static AudioSource[] Sounds;

    private void Start()
    {
        for (int i = 0; i < Sounds.Length; i++)
        {
            Sounds[i] = audioSources[i];
        }
    }

}
