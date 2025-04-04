using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    public static AudioSource[] Sounds;

    private void Start()
    {
        Sounds = audioSources;
    }

    public static AudioSource FindSound(string name)
    {
        for (int i = 0; i < Sounds.Length; i++)
        {
            if (Sounds[i].name == name)
            {
                return Sounds[i];
            }
        }
        return null;
    }
}
