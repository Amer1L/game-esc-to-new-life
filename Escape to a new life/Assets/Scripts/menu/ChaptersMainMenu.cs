using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChaptersMainMenu : MonoBehaviour
{
    private float _firstpos;

    private void Start()
    {
        _firstpos = transform.localPosition.x;
    }

    private void OnMouseEnter()
    {
        PositionShift(new Vector3(_firstpos + 0.1f - transform.localPosition.x, 0, 0), 0.05f);
    }

    private void OnMouseExit()
    {
        PositionShift(new Vector3(_firstpos - transform.localPosition.x, 0, 0), 0.05f);
    }

    private void PositionShift(Vector3 offset, float time)
    {
        StartCoroutine(PositionShiftRoutine(offset, time));
    }

    private IEnumerator PositionShiftRoutine(Vector3 offset, float time)
    {
        Vector3 startPosition = transform.localPosition;
        Vector3 targetPosition = startPosition + offset;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetPosition;
    }
}