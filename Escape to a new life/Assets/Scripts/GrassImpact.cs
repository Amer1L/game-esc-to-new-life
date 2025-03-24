using UnityEngine;
using System.Collections;

public class GrassImpact : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }

}
