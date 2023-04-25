using UnityEngine;

public class Wings : MonoBehaviour
{
    public float rotationAngle = 45f; // Angle to rotate by in degrees
    public float rotationRate = 1f; // Rotation rate in degrees per second

    private float currentRotationAngle; // Current angle of rotation

    void Update()
    {
        // Calculate the new rotation angle based on the rotation rate and the elapsed time since the last frame
        float deltaAngle = rotationRate * Time.deltaTime;
        currentRotationAngle += deltaAngle;

        // If the current rotation angle exceeds the target angle, wrap around to start over
        if (currentRotationAngle >= rotationAngle)
        {
            currentRotationAngle = 0f;
        }

        // Rotate the object by the current rotation angle around the Y-axis
        transform.rotation = Quaternion.Euler(0f, currentRotationAngle, 0f);
    }
}
