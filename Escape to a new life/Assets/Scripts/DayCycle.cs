using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{

    [SerializeField] private float _rateRotate = 0.5f;

    void Update()
    {
        transform.Rotate(0, 0, _rateRotate * Time.deltaTime);
    }
}
