using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject[] _resources;
    [SerializeField] private Sprite[] _Atrunk;
    [SerializeField] private Sprite[] _AtreeHand;
    [SerializeField] private SpriteRenderer _trunk;
    [SerializeField] private SpriteRenderer _treeHand;
    [SerializeField] private Animator _anim;
    private float _endurance = 25;
    private float _timer = 0;

    void Start()
    {
        int random = Random.Range(0, _Atrunk.Length);
        _trunk.sprite = _Atrunk[random];
        random = Random.Range(0, _AtreeHand.Length);
        _treeHand.sprite = _AtreeHand[random];
    }

    void Update()
    {
        if(_endurance <= 0)
        {
            Deletion();
        }

        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _anim.SetBool("isHit", false);
        }

    }

    private void Deletion()
    {
        Instantiate(_resources[0], transform);
        Instantiate(_resources[1], transform);
        if (Random.Range(0, 3) == 2)
        {
            Instantiate(_resources[2], transform);
        }
        else if (Random.Range(0, 3) == 2)
        {
            Instantiate(_resources[0], transform);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>())
        {
            Debug.Log(collision.gameObject.name);
            if(VelocityOutOfRange(collision.gameObject.GetComponent<Rigidbody2D>(), 3 * collision.gameObject.GetComponent<Rigidbody2D>().mass))
            {
                _anim.SetBool("isHit", true);
                _endurance -= 9;
                Debug.Log(_endurance);
                _timer = 0.2f;
            }
        }
    }

    private bool VelocityOutOfRange(Rigidbody2D rb, float upBorder)
    {
        if (rb.velocity.x >= upBorder || rb.velocity.x <= -upBorder || rb.velocity.y >= upBorder || rb.velocity.y <= -upBorder || (rb.velocity.x + rb.velocity.y) <= -upBorder || (rb.velocity.x + rb.velocity.y) >= upBorder)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
