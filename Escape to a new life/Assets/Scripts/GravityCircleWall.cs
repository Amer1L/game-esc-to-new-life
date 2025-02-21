using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCircleWall : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private ChangeObject changeObject;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
                changeObject.Disactivate();

            collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Vector2 planetCenter = Vector2.zero;
            Vector2 directionToPlanet = (planetCenter - (Vector2)transform.position).normalized;
            collision.GetComponent<Rigidbody2D>().AddForce(directionToPlanet * 500, ForceMode2D.Force);
        }
    }
}
