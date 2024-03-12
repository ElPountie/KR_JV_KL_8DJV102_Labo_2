using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour
{
    private Vector3 initPos;
    public PlayerInputActions InputAction;
    public InputAction LaunchAction;
    public float launchStrength = 1000f;
    public float launchOffset = 0.01f;
    public float maxDistance = 1.05f;
    private bool launched = false;
    private bool launching = false;
    private Rigidbody rb;

    private void Awake()
    {
        InputAction = new PlayerInputActions();
    }

    void Start()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        LaunchAction = InputAction.Player.LaunchBall;

        LaunchAction.Enable();
        LaunchAction.started += OnLaunchActionStarted;
        LaunchAction.canceled += OnLaunchActionCanceled;
    }
    private void OnDisable()
    {
        LaunchAction.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(launching)
        {
            if(transform.position.z <= initPos.z + maxDistance)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + launchOffset);
            }
        }
        else if(launched)
        {
            if (transform.position.z <= initPos.z)
            {
                rb.velocity = Vector3.zero;
                Debug.Log(rb.velocity);
                transform.position = initPos;
                launched = false;
            }
            else
            {
                rb.AddForce(Vector3.back * launchStrength);
            }
            
        }
    }

    private void OnLaunchActionStarted(InputAction.CallbackContext context)
    {
        launching = true;
    }
    private void OnLaunchActionCanceled(InputAction.CallbackContext context)
    {
        launching = false;
        launched = true;
    }
}
