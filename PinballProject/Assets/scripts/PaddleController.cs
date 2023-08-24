using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;

    private float targetPressed;
    private float targetRelease;
    private HingeJoint hingeJoint;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();

        targetPressed = hingeJoint.limits.max;
        targetRelease = hingeJoint.limits.min;
    }
        
    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hingeJoint.spring;

        if (Input.GetKey(input))
        {
           jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }
        
        hingeJoint.spring = jointSpring;
    }
}
