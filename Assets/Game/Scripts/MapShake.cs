using UnityEngine;
using TMPro;

public class MapShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // Duration of the shake
    public float shakeIntensity = 0.1f; // Intensity of the shake
    public float shakeSpeed = 10f; // Speed of the shake
    public float maxShakeIntensity = 0.5f; // Maximum intensity for displaying message
    public int maxShakeCount = 5; // Maximum number of shakes allowed
    public TMP_Text shakeMessageText; // Reference to the UI Text element

    private Vector3 originalPosition;
    private float shakeTimer;
    private int shakeCount;

    private void Start()
    {
        // Store the original position of the map
        originalPosition = transform.position;
        // Hide the shake message initially
        HideShakeMessage();
        // Reset shake count
        shakeCount = 0;
    }

    private void Update()
    {
        // Check if spacebar is pressed and shake timer is not active
        if (Input.GetKeyDown(KeyCode.Space) && shakeTimer <= 0 && shakeCount < maxShakeCount)
        {
            // Start the shake
            shakeTimer = shakeDuration;
            shakeCount++;
        }

        if (shakeCount >= maxShakeCount)
        {
            ShowShakeMessage();
        }
        else
        {
            HideShakeMessage();
        }

        // Update the shake effect if timer is active
        if (shakeTimer > 0)
        {
            // Calculate shake offset using Perlin noise
            float shakeOffsetX = Mathf.PerlinNoise(Time.time * shakeSpeed, 0) * 2 - 1;
            float shakeOffsetY = Mathf.PerlinNoise(0, Time.time * shakeSpeed) * 2 - 1;

            // Apply the shake to the map's position
            transform.position = originalPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0) * shakeIntensity;

            // Decrease the shake timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset map position when shake is finished
            transform.position = originalPosition;
        }
    }

    private void ShowShakeMessage()
    {
        if (shakeMessageText.text != null)
        {
            shakeMessageText.text = "TILTED";
        }
    }

    private void HideShakeMessage()
    {
        if (shakeMessageText.text != null)
        {
            shakeMessageText.text = "";
        }
    }
}
