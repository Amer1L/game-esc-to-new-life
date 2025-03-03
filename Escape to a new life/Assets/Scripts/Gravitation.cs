using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField] private float _gravityForce;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {

            Vector2 planetCenter = Vector2.zero;
            Vector2 directionToPlanet = (planetCenter - (Vector2)collision.transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(directionToPlanet * _gravityForce * collision.gameObject.GetComponent<Rigidbody2D>().mass, ForceMode2D.Force);
        }
    }
}
