using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _gravityForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Rigidbody2D _RBplayer;
    [SerializeField] private Animator _walkAnim;


    void Update()
    {
        if (VelocityOutOfRange(_RBplayer, 20))
        {
            _RBplayer.velocity = _RBplayer.velocity / 5;
        }

        Vector2 planetCenter = Vector2.zero;
        Vector2 directionToPlanet = (planetCenter - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(directionToPlanet.y, directionToPlanet.x) * Mathf.Rad2Deg;
        _RBplayer.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        _RBplayer.AddForce(directionToPlanet * _gravityForce, ForceMode2D.Force);
        if(!isGrounded)
        {
            _walkAnim.SetBool("IsJump", true);
        }
        else
        {
            _walkAnim.SetBool("IsJump", false);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private bool VelocityOutOfRange(Rigidbody2D rb, float upBorder)
    {
        if (rb.velocity.x >= upBorder || rb.velocity.x <= -upBorder || rb.velocity.y >= upBorder || rb.velocity.y <= -upBorder)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}