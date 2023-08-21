using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public KeyCode input;
    public float minForce = 100;
    public float maxForce = 1000;
    public float maxHoldTime = 3f;

    public Gradient powerColor;
    private Renderer renderer;

    private Collider ballCollider;
    private bool canLaunch = false;
    private float pushForce = 0;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            ballCollider = collision.collider;
            StartCoroutine(TimerCount());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            ballCollider = null;
            StopAllCoroutines();
            canLaunch = false;
        }
    }

    private IEnumerator TimerCount()
    {
        yield return new WaitForSeconds(.6f);
        pushForce = 0f;
        canLaunch = true;
        renderer.material.color = Color.white;
    }

    private void Update()
    {
        if (!canLaunch) return;

        if (Input.GetKey(input))
        {
            pushForce += Time.deltaTime * maxForce / maxHoldTime;
            pushForce = Mathf.Clamp(pushForce, minForce, maxForce);
            renderer.material.color = powerColor.Evaluate((pushForce - minForce) / (maxForce - minForce));
        }

        if (Input.GetKeyUp(input))
        {
            ballCollider.attachedRigidbody.AddForce(Vector3.forward * pushForce);
            pushForce = 0f;
        }
    }
}
