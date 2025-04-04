using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStick : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private Animator _animator;
    private bool isFlame = true;

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Click()
    {
        isFlame = !isFlame;
        _animator.SetBool("isFlame", isFlame);
        _light.SetActive(isFlame);
        if (isFlame)
        {
            SoundLibrary.FindSound("StillFire").Play();
        }
        else
        {
            SoundLibrary.FindSound("StillFire").Stop();
        }
    }
}
