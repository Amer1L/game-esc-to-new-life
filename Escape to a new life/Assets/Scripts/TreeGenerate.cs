using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerate : MonoBehaviour
{
    [SerializeField] private GameObject _Tree;
    private bool[] _freePlaces = new bool[36];

    void Start()
    {
        for (int i = 0; i < 36; i++)
        {
            _freePlaces[i] = true;
        }
        Generate();
    }


    public void Generate()
    {
        for (int i = 0; i < 9; i++)
        {
            bool created = false;
            while (!created)
            {
                int random = Random.Range(0, 36);
                if (_freePlaces[random])
                {
                    GameObject tree = Instantiate(_Tree, Vector3.zero, Quaternion.Euler(0, 0, random * 10));
                    created = true;
                    _freePlaces[random] = false;
                }
            }
        }
    }
}
