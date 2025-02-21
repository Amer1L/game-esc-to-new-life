using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{

    [SerializeField] private float tiltAmount = 10f;
    [SerializeField] private float tiltSpeed = 5f;

    private Vector2 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector2 movementDirection = ((Vector2)transform.position - lastPosition).normalized;
        float tiltAngle = -movementDirection.x * tiltAmount;
        Quaternion targetRotation = Quaternion.Euler(0, 0, tiltAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
        lastPosition = transform.position;
    }

}
