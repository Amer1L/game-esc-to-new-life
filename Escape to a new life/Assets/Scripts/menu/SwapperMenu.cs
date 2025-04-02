using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapperMenu : MonoBehaviour
{
    [SerializeField] private GameObject thisMenu;
    [SerializeField] private Transform menuA;
    [SerializeField] private Transform menuB;


    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Menu.menuOpen == thisMenu)
        {
            StartCoroutine(SwapRoutine(0.25f));
            Menu.menuOpen = menuB.gameObject;
        }
    }

    private IEnumerator SwapRoutine(float time)
    {
        Vector3 startPosA = menuA.position;
        Vector3 startPosB = menuB.position;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            menuA.position = Vector3.Lerp(startPosA, startPosB, t);
            menuB.position = Vector3.Lerp(startPosB, startPosA, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        menuA.position = startPosB;
        menuB.position = startPosA;
    }
}
