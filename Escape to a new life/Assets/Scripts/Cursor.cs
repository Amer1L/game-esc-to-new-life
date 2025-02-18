using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    [SerializeField] private GameObject _cursorTarget;
    [SerializeField] private Camera _camera;

    private GameObject _keepBlock;
    private int _r = 1;
    private bool _mouseActive;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Activate();
            _mouseActive = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Disactivate();
            _mouseActive = false;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_mouseActive)
        {
            _cursorTarget.GetComponent<Rigidbody2D>().velocity = new Vector2((mousePos.x - _cursorTarget.transform.position.x) * 20f, (mousePos.y - _cursorTarget.transform.position.y) * 20f);
        }
        else
        {
            _cursorTarget.transform.position = new Vector3(mousePos.x, mousePos.y, -50);
        }
    }

    public void Activate()
    {
        _r = 1;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);

        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>())
        {
            _keepBlock = hit.collider.gameObject;
            _cursorTarget.GetComponent<HingeJoint2D>().enabled = true;
            _cursorTarget.GetComponent<HingeJoint2D>().connectedBody = _keepBlock.GetComponent<Rigidbody2D>();
        }
    }

    public void Disactivate()
    {

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
        _keepBlock = null;
    }
}
