using System.Collections;
using UnityEngine;

public class AActor : MonoBehaviour
{
    [SerializeField] protected float _movingSpeed = 5f;
    protected bool _isMoving = false;
    public bool isMoving => _isMoving;

    public void Initialize()
    {
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            0
        );
        _isMoving = false;
    }

    public void Move(Vector3 direction)
    {
        if (_isMoving)
        {
            return;
        }

        Vector3 targetPosition = transform.position + direction;
        if (CanMoveTo(direction))
        {
            StartCoroutine(SmoothMove(targetPosition));
        }
    }

    public bool CanMoveTo(Vector3 direction)
    {
        return true;
    }

    private IEnumerator SmoothMove(Vector3 targetPosition)
    {
        _isMoving = true;
        Vector3 startPosition = transform.position;
        float movementLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (transform.position != targetPosition)
        {
            float distance = (Time.time - startTime) * _movingSpeed;
            float fractionOfMovement = distance / movementLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfMovement);
            yield return null;
        }

        transform.position = targetPosition;
        _isMoving = false;
    }
}
