using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;

    private Transform target;
    private float distance;
    private Vector3 defaultPosition;

    public bool hasTarget => target != null;

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
        if (!hasTarget) return;

        Vector3 targetToCameraDir = transform.rotation * -Vector3.forward;
        Vector3 targetPosition = target.position + targetToCameraDir * distance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    public void FollowTarget(Transform targetTransform, float distance)
    {
        this.distance = distance;
        target = targetTransform;

        StopAllCoroutines();
    }

    public void ResetTarget()
    {
        target = null;

        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 targetPos, float time)
    {
        float timer = 0;
        Vector3 startPos = transform.position;

        while(timer < time)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, Mathf.SmoothStep(0, 1, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = targetPos;
    }
}
