using UnityEngine;
using System.Collections;

public class ChaptersMainMenu : MonoBehaviour
{
    [SerializeField] private Collider2D _cursor;
    [SerializeField] private float _firstPos;
    [SerializeField] private float _secondPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == _cursor)
        {
            PositionShift(new Vector3(_secondPos - transform.position.x, 0, 0), 0.05f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _cursor)
        {
            PositionShift(new Vector3(_firstPos - transform.position.x, 0, 0), 0.05f);
        }
    }

    private void PositionShift(Vector3 offset, float time)
    {
        StartCoroutine(PositionShiftRoutine(offset, time));
    }

    private IEnumerator PositionShiftRoutine(Vector3 offset, float time)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + offset;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}