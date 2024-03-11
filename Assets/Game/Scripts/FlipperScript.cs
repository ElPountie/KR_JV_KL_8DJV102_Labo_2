using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    public bool isLeftFlipper;

    public PlayerInputActions InputAction;
    public InputAction leftFlipper;
    public InputAction rightFlipper;

    HingeJoint hinge;


    private void Awake()
    {
        InputAction = new PlayerInputActions();
    }

    private void OnEnable()
    {
        if (isLeftFlipper)
        {
            leftFlipper = InputAction.Player.LeftFlipper;
            leftFlipper.Enable();
            leftFlipper.started += LeftFlipperActionStarted;
            leftFlipper.canceled += LeftFlipperActionCanceled;
        }
        else
        {
            rightFlipper = InputAction.Player.RightFlipper;
            rightFlipper.Enable();
            rightFlipper.started += RightFlipperActionStarted;
            rightFlipper.canceled += RightFlipperActionCanceled;
        }
    }
    
    private void OnDisable()
    {
        if (isLeftFlipper)
        {
            leftFlipper.Disable();
        }
        else
        {
            rightFlipper.Disable();
        }
    }

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    public void RightFlipperActionStarted(InputAction.CallbackContext context)
    {
        if (!isLeftFlipper)
        {
            JointSpring spring = new JointSpring();
            spring.spring = hitStrength;
            spring.damper = flipperDamper;
            spring.targetPosition = pressedPosition;
            hinge.spring = spring;
            hinge.useLimits = true;
        }
    }

    public void RightFlipperActionCanceled(InputAction.CallbackContext context)
    {
        if (!isLeftFlipper)
        {
            JointSpring spring = new JointSpring();
            spring.spring = hitStrength;
            spring.damper = flipperDamper;
            spring.targetPosition = restPosition;
            hinge.spring = spring;
            hinge.useLimits = true;
        }
    }

    public void LeftFlipperActionStarted(InputAction.CallbackContext context)
    {
        if (isLeftFlipper)
        {
            JointSpring spring = new JointSpring();
            spring.spring = hitStrength;
            spring.damper = flipperDamper;
            spring.targetPosition = pressedPosition;
            hinge.spring = spring;
            hinge.useLimits = true;
        }
    }

    public void LeftFlipperActionCanceled(InputAction.CallbackContext context)
    {
        if (isLeftFlipper)
        {
            JointSpring spring = new JointSpring();
            spring.spring = hitStrength;
            spring.damper = flipperDamper;
            spring.targetPosition = restPosition;
            hinge.spring = spring;
            hinge.useLimits = true;
        }
    }
}
