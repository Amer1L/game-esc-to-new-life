using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGrass : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("grassImpact", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool("grassImpact", false);

    }
}
