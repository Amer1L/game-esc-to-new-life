using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _ASclick;
    [SerializeField] private Animator _cursorAnim;

    void Update()
    {
        Cursor.visible = false;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _cursorAnim.transform.position = new Vector3(mousePos.x, mousePos.y, _cursorAnim.transform.position.z);


        if (Input.GetMouseButtonDown(0))
        {
            _cursorAnim.SetBool("IsClick", true);
            Debug.Log("0");
            Click();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _cursorAnim.SetBool("IsClick", false);
        }
    }

    private void Click()
    {
    }
}
