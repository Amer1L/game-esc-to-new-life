using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprCurs;
    [SerializeField] private SpriteRenderer _UICursor;
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private GameObject _cursorTarget;
    [SerializeField] private Camera _camera;

    private Rigidbody2D _rbItem;
    private bool _objectTaken = false;
    private GameObject _keepBlock;
    private int _r = 1;
    private bool _mouseActive;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {

        Cursor.visible = false;
        if (Input.GetMouseButtonDown(0))
        {
            Activate();
            _mouseActive = true;
            _UICursor.sprite = _sprCurs[1];
        }
        if (Input.GetMouseButtonUp(0))
        {
            Disactivate();
            _mouseActive = false;
            _UICursor.sprite = _sprCurs[0];
        }

        if (_objectTaken)
        {
            if (VelocityOutOfRange(_rbItem, 65))
            {
                _rbItem.velocity = _rbItem.velocity * 0.8f;
            }

            if (_rbItem == _playerRB && VelocityOutOfRange(_rbItem, 10))
            {
                _rbItem.velocity = _rbItem.velocity * 0.91f;
            }


        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _UICursor.transform.position = new Vector3(mousePos.x, mousePos.y, -58);
        if (_mouseActive)
        {
            _cursorTarget.GetComponent<Rigidbody2D>().velocity = new Vector2((mousePos.x - _cursorTarget.transform.position.x) * 20f, (mousePos.y - _cursorTarget.transform.position.y) * 20f);
        }
        else
        {
            _cursorTarget.transform.position = new Vector3(mousePos.x, mousePos.y, -50);
        }
    }

    private void Activate()
    {
        _r = 1;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);

        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>())
        {
            _objectTaken = true;
            _keepBlock = hit.collider.gameObject;
            _rbItem = _keepBlock.GetComponent<Rigidbody2D>();
            _cursorTarget.GetComponent<HingeJoint2D>().enabled = true;
            _cursorTarget.GetComponent<HingeJoint2D>().connectedBody = _keepBlock.GetComponent<Rigidbody2D>();
        }

    }

    public void Disactivate()
    {
        if (_objectTaken)
        {
            if (VelocityOutOfRange(_rbItem, 65))
            {
                _rbItem.velocity = _rbItem.velocity / 3;
            }
            else
            {
                _rbItem.velocity = _keepBlock.GetComponent<Rigidbody2D>().velocity / 3;
            }
        }



        if (_r == 1)
        {
            _cursorTarget.GetComponent<HingeJoint2D>().connectedBody = null;
            _cursorTarget.GetComponent<HingeJoint2D>().enabled = false;
        }
        if (_r == 2)
        {
            _cursorTarget.GetComponent<FixedJoint2D>().connectedBody = null;
            _cursorTarget.GetComponent<FixedJoint2D>().enabled = false;
            _cursorTarget.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        _objectTaken = false;
        _keepBlock = null;
        _rbItem = null;
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
