using UnityEngine;

public class FireSpinner : MonoBehaviour
{
    [Tooltip("Speed of rotation in degrees per second")]
    public float rotationSpeed = 90f;

    [Tooltip("Invert rotation direction")]
    public bool invertRotation = false;

    void Update()
    {
        float direction = invertRotation ? -1f : 1f;
        transform.Rotate(Vector3.up * rotationSpeed * direction * Time.deltaTime);
    }
}
