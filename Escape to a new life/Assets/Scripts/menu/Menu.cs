using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    public static GameObject menuOpen;

    private void Start()
    {
        menuOpen = mainMenu;
    }
}
