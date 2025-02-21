using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopZoneVelocity : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
