using UnityEngine;

public class PlaneCollisionHandler : MonoBehaviour
{
    // Adjust this value to control how much the ball's velocity is reduced
    public float friction = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                // Reduce the ball's velocity
                ballRigidbody.velocity *= friction;
            }
        }
    }
}
