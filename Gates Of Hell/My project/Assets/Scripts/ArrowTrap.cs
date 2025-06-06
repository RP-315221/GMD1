using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour
{
    public float rotationInterval = 3f;
    public float initialDelay = 0.5f;
    public float rotationAmount = 90f;
    public float rotationSpeed = 180f; // Degrees per second

    private Quaternion targetRotation;
    private bool isRotating = false;

    private void Start()
    {
        targetRotation = transform.rotation;
        StartCoroutine(RotateRoutine());
    }

    private void Update()
    {
        if (isRotating)
        {
            // Smoothly rotate toward target
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // Stop rotating once close enough
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    IEnumerator RotateRoutine()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Set next target rotation
            targetRotation *= Quaternion.Euler(0f, rotationAmount, 0f);
            isRotating = true;

            // Wait until finished rotating before next interval
            yield return new WaitForSeconds(rotationInterval);
        }
    }
}
