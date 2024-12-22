using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _RBplayer;
    [SerializeField] private Animator _walkAnim;
    [SerializeField] private float _forceJump;
    [SerializeField] private Vector2 _flipCollOfset;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointPlayer;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private Collider2D _flipZone;



    void Update()
    {


        float movement = Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_RBplayer.velocity.y) < 0.05)
        {
            _walkAnim.SetBool("IsJump", true);
            _RBplayer.AddForce(new Vector2(0, _forceJump), ForceMode2D.Impulse);
        }
        if(Mathf.Abs(_RBplayer.velocity.y) < 0.05)
        {
            _walkAnim.SetBool("IsJump", false);
        }
        

        if (movement < 0)
        {
            _player.flipX = true;
            _flipZone.offset = -_flipCollOfset;
            
        }
        if (movement > 0)
        {
            _player.flipX = false;
            _flipZone.offset = _flipCollOfset;
        }


        if (movement < 0 || movement > 0)
        {
            _walkAnim.SetBool("IsWalk", true);
        }
        else
        {
            _walkAnim.SetBool("IsWalk", false);
        }


        _pointPlayer.Rotate(0, 0, movement * _speed * Time.deltaTime * -1);

    }
}
