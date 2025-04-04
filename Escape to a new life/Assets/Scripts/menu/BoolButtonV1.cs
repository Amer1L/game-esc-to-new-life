using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolButtonV1 : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool _isOn = false;

    private void OnMouseDown()
    {
        _isOn = !_isOn;
        _anim.SetBool("isOn", _isOn);
        SoundLibrary.FindSound("Catch").Play();
    }
}
