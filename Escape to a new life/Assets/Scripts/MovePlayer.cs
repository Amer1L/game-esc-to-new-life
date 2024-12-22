using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Rigidbody2D _RBplayer;
    [SerializeField] private Animator _walkAnim;
    [SerializeField] private Vector2 _flipCollOfset;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private Collider2D _flipZone;



    void Update()
    {

        Vector2 planetCenter = Vector2.zero;
        Vector2 directionToPlanet = (planetCenter - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(directionToPlanet.y, directionToPlanet.x) * Mathf.Rad2Deg;
        _RBplayer.transform.rotation = Quaternion.Euler(0, 0, angle + 90);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _walkAnim.SetBool("IsJump", true);
            Jump();
        }
        if(isGrounded)
        {
            _walkAnim.SetBool("IsJump", false);
        }
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");

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

        Vector2 planetCenter = Vector2.zero;
        Vector2 directionToPlanet = (planetCenter - (Vector2)transform.position).normalized;
        Vector2 tangent = new Vector2(-directionToPlanet.y, directionToPlanet.x);

        _RBplayer.velocity = tangent * movement * _speed;
    }

    void Jump()
    {
        Vector2 planetCenter = Vector2.zero;
        Vector2 directionToPlanet = (transform.position - (Vector3)planetCenter).normalized;

        _RBplayer.AddForce(directionToPlanet * jumpForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
