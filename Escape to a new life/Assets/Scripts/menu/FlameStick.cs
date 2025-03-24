using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStick : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    [SerializeField] private Animator _animator;
    private bool isFlame = true;

    public void Click()
    {
        isFlame = !isFlame;
        _animator.SetBool("isFlame", isFlame);
        _light.SetActive(isFlame);
        Debug.Log("4");
    }
}
