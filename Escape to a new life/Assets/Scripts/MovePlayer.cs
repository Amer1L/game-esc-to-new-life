using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private Transform _planet;
    [SerializeField] private Transform _camera;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private Animator _walkAnim;
    [SerializeField] private float _speed;



    void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        if (movement < 0)
        {
            _player.flipX = true;
        }
        if (movement > 0)
        {
            _player.flipX = false;
        }


        if(movement < 0 || movement > 0)
        {
            _walkAnim.SetBool("IsWalk", true);
        }
        else
        {
            _walkAnim.SetBool("IsWalk", false);
        }

        _planet.Rotate(0, 0, movement * _speed * Time.deltaTime);
        _camera.Rotate(0, 0, movement * _speed * Time.deltaTime);


    }
}
