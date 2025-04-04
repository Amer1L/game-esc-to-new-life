using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNewGame : MonoBehaviour
{
    [SerializeField] private GameObject thisMenu;
    [SerializeField] private string _sceneName;


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)/* && Menu.menuOpen == thisMenu*/)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
