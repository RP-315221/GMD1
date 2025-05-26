using UnityEngine;
using System.Collections;

public class SawbladeTrap : MonoBehaviour
{
    public Transform trapHome;               // Reference to Traphome_Mid
    public float moveSpeed = 2f;             // Movement speed
    public float rotationSpeed = 180f;       // Saw rotation speed (degrees/sec)
    public float moveDistance = 2f;          // Distance from center to each side
    public float timeOffset = 0.5f;          // Delay before saw starts moving
    public Vector3 rotationAxis = Vector3.up; // ✅ Inspector-settable rotation axis

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

        // Calculate center-based positions based on trap orientation
        Vector3 center = transform.position;
        startPos = center - trapHome.right * moveDistance;
        targetPos = center + trapHome.right * moveDistance;

        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(timeOffset);
        active = true;
    }

    void Update()
    {
        // ✅ Rotate on user-defined axis in world space
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime, Space.World);

        if (!active)
            return;

        // Move saw back and forth
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
