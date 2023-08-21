using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{
    public CameraController CameraController;
    public float zoomDistance = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CameraController.FollowTarget(other.transform, zoomDistance);
        }
    }
}
