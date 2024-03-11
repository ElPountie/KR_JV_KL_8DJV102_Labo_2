using UnityEngine;
using UnityEngine.InputSystem;

public enum PadState
{
    Left,
    Right,
    Other
}

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    public PadState padState;

    public PlayerInputActions InputAction;
    public InputAction flipperAction;

    HingeJoint hinge;

    private void Awake()
    {
        InputAction = new PlayerInputActions();
    }

    private void OnEnable()
    {
        if (padState == PadState.Left)
        {
            flipperAction = InputAction.Player.LeftFlipper;
        }
        else if (padState == PadState.Right)
        {
            flipperAction = InputAction.Player.RightFlipper;
        }
        else if (padState == PadState.Other)
        {
            flipperAction = InputAction.Player.OtherPad;
        }

        flipperAction.Enable();
        flipperAction.started += OnFlipperActionStarted;
        flipperAction.canceled += OnFlipperActionCanceled;
    }

    private void OnDisable()
    {
        flipperAction.Disable();
    }

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    private void OnFlipperActionStarted(InputAction.CallbackContext context)
    {
        ApplySpringSettings(pressedPosition);
    }

    private void OnFlipperActionCanceled(InputAction.CallbackContext context)
    {
        ApplySpringSettings(restPosition);
    }

    private void ApplySpringSettings(float targetPosition)
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;
        spring.targetPosition = targetPosition;
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
