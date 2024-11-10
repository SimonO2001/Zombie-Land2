using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Reference to the player’s Transform
    public float smoothSpeed = 0.125f; // Adjust this for smoothness
    public Vector3 offset;          // Offset to position the camera slightly above the player

    void LateUpdate()
    {
        // Target position with offset
        Vector3 desiredPosition = player.position + offset;
        // Smoothly transition to that position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
