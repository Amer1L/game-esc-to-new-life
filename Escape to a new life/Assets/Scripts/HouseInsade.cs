using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInsade : MonoBehaviour
{

    [SerializeField] private GameObject _houseOutSprite;
    [SerializeField] private GameObject _insideObject;
    [SerializeField] private Collider2D _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == _player)
        {
            _houseOutSprite.SetActive(false);
            _insideObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _player)
        {
            _houseOutSprite.SetActive(true);
            _insideObject.SetActive(false);
        }
    }

}
