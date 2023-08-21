using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode inputKey;

    private HingeJoint hinge;
    private JointSpring jointSpring;
    private float targetPressedPos;
    private float targetReleasePos;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        jointSpring = hinge.spring;
        targetPressedPos = hinge.limits.max;
        targetReleasePos = hinge.limits.min;
    }

    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetKey(inputKey))
        {
            jointSpring.targetPosition = targetPressedPos;
        }
        else
        {
            jointSpring.targetPosition = targetReleasePos;
        }

        hinge.spring = jointSpring;
    }
}
