using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInsade : MonoBehaviour
{

    [SerializeField] private GameObject _outsideLight;
    [SerializeField] private GameObject _houseOutSprite;
    [SerializeField] private GameObject _insideObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _outsideLight.SetActive(false);
        _houseOutSprite.SetActive(false);
        _insideObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _outsideLight.SetActive(true);
        _houseOutSprite.SetActive(true);
        _insideObject.SetActive(false);
    }

}
