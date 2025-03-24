using UnityEditor;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    public GameObject[] grassPrefab;
    public int grassCount;
    public float planetRadius;
    private Transform grassContainer;

    void Start()
    {
        grassContainer = new GameObject("GrassContainer").transform;
        grassContainer.parent = transform;

        GenerateGrass();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            GenerateGrass();
        }
    }

    void GenerateGrass()
    {
        for (int i = 0; i < grassCount; i++)
        {
            float angle = Random.Range(0f, 360f);
            float radians = angle * Mathf.Deg2Rad;

            Vector2 position = new Vector2(
                Mathf.Cos(radians) * planetRadius,
                Mathf.Sin(radians) * planetRadius
            );

            GameObject grass = Instantiate(grassPrefab[Random.Range(0, grassPrefab.Length)], position, Quaternion.identity, grassContainer);
            int flip = Random.Range(0, 2);
            if(flip == 0)
            {
                grass.GetComponent<SpriteRenderer>().flipX = true;
            }
            grass.transform.localScale *= Random.Range(1f, 1.2f);
            grass.transform.up = position.normalized;
        }
    }
}