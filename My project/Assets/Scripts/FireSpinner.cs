using UnityEngine;

public class FireSpinner : MonoBehaviour
{
    [Tooltip("Speed of rotation in degrees per second")]
    public float rotationSpeed = 90f;

    void Update()
    {
        // Rotate around the Y axis at a constant rate
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
