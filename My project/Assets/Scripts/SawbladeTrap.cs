using UnityEngine;
using System.Collections;

public class SawbladeTrap : MonoBehaviour
{
    public Transform trapHome;              // Reference to Traphome_Mid
    public float moveSpeed = 2f;            // Movement speed
    public float rotationSpeed = 180f;      // Saw rotation speed
    public float moveDistance = 2f;         // Total move distance from center
    public float timeOffset = 0.5f;         // ⏱ Delay before saw starts moving

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingForward = true;
    private bool active = false;

    void Start()
    {
        if (trapHome == null)
        {
            Debug.LogError("Trap Home reference not set!");
            enabled = false;
            return;
        }

        // Calculate movement range based on trapHome's orientation
        Vector3 center = transform.position;
        startPos = center - trapHome.right * moveDistance;
        targetPos = center + trapHome.right * moveDistance;

        // Delay activation
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(timeOffset);
        active = true;
    }

    void Update()
    {
        // Always rotate, even before moving
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime, Space.World);

        if (!active)
            return;

        // Move back and forth between start and target positions
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
