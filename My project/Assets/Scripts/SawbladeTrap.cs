using UnityEngine;

public class SawbladeTrap : MonoBehaviour
{
    public Transform trapHome; // Reference to the Traphome_Mid
    public float moveSpeed = 2f;
    public float rotationSpeed = 180f; // degrees per second
    public float moveDistance = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingForward = true;

    void Start()
    {
        if (trapHome == null)
        {
            Debug.LogError("Trap Home reference not set!");
            enabled = false;
            return;
        }

        // Use initial sawblade position as center
        Vector3 center = transform.position;

        startPos = center - trapHome.right * moveDistance;
        targetPos = center + trapHome.right * moveDistance;
    }


    void Update()
    {
        // Rotate clockwise on Y axis
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.World);

        // Move back and forth on X axis (relative to trapHome's right vector)
        Vector3 dir = (movingForward ? targetPos : startPos) - transform.position;
        float step = moveSpeed * Time.deltaTime;

        if (dir.magnitude <= step)
        {
            transform.position = movingForward ? targetPos : startPos;
            movingForward = !movingForward;
        }
        else
        {
            transform.position += dir.normalized * step;
        }
    }
}
