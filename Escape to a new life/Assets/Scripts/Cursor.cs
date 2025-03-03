using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ChangeObject : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprCurs;
    [SerializeField] private SpriteRenderer _UICursor;
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private GameObject _cursorTarget;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _borderPlayer;
    [SerializeField] private AudioSource _catch;
    [SerializeField] private TextMeshPro _nameObject;

    private Rigidbody2D _rbItem;
    private bool _objectTaken = false;
    private GameObject _keepBlock;
    private int _r = 1;
    private bool _mouseActive;
    private ParticleSystem.EmissionModule emissionModule;

    private void Start()
    {
        _camera = Camera.main;
        emissionModule = _borderPlayer.emission;
    }

    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 1, Input.mousePosition.z)), transform.forward);

        if (hit.collider != null && hit.collider.gameObject.GetComponent<AttributeCatchObject>() && !_objectTaken)
        {
            _nameObject.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y + 2, _nameObject.transform.position.z);
            AttributeCatchObject attribute = hit.collider.gameObject.GetComponent<AttributeCatchObject>();

            _nameObject.text = attribute.NameItem;
        }
        else
        {
            _nameObject.text = " ";
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
            _rbItem.velocity = Vector2.zero;
            _cursorTarget.GetComponent<HingeJoint2D>().enabled = true;
            _cursorTarget.GetComponent<HingeJoint2D>().connectedBody = _keepBlock.GetComponent<Rigidbody2D>();
            if (_rbItem == _playerRB)
            {
                emissionModule.rateOverTime = 1800;
            }
        }
        _catch.Play();
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
            _cursorTarget.GetComponent<HingeJoint2D>().enabled = false;
            _cursorTarget.GetComponent<HingeJoint2D>().connectedBody = null;
        }
        if (_r == 2)
        {
            _cursorTarget.GetComponent<FixedJoint2D>().enabled = false;
            _cursorTarget.GetComponent<FixedJoint2D>().connectedBody = null;
            _cursorTarget.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        _objectTaken = false;
        _keepBlock = null;
        _rbItem = null;
        emissionModule.rateOverTime = 0;
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
