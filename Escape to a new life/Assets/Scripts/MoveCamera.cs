using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _smothTime = 0.15f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -60);
    [SerializeField] private Transform target;

    private Vector3 _velocity = Vector3.zero;


    void LateUpdate()
    {

        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smothTime);

    }
}