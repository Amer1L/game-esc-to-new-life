using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttributeCatchObject : MonoBehaviour
{
    public AudioSource Catch;
    public AudioSource Hit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Hit != null)
        {
            Hit.volume = Hit.volume * ((GetComponent<Rigidbody2D>().velocity.x + GetComponent<Rigidbody2D>().velocity.y) / 1);
            Hit.Play();
        }
    }
}
