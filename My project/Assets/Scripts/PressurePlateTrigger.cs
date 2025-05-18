using UnityEngine;
using System.Collections;

public class PressurePlateTrigger : MonoBehaviour
{
    public Transform gate;
    public float plateLowerAmount = 0.2f;
    public float gateLowerAmount = 2f;
    public float moveDuration = 1f;
    public float stayDuration = 10f;

    private Vector3 plateInitialPos;
    private Vector3 gateInitialPos;
    private bool isActivated = false;

    void Start()
    {
        // Store initial positions once
        plateInitialPos = transform.position;

        if (gate != null)
            gateInitialPos = gate.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            StartCoroutine(ActivatePlate());
        }
    }

    IEnumerator ActivatePlate()
    {
        isActivated = true;

        Vector3 plateLoweredPos = plateInitialPos - new Vector3(0f, plateLowerAmount, 0f);
        Vector3 gateLoweredPos = gateInitialPos - new Vector3(0f, gateLowerAmount, 0f);

        // Lower plate and gate
        yield return StartCoroutine(MoveObject(transform, plateLoweredPos, moveDuration));
        if (gate != null)
            yield return StartCoroutine(MoveObject(gate, gateLoweredPos, moveDuration));

        // Wait
        yield return new WaitForSeconds(stayDuration);

        // Raise gate and plate back up
        if (gate != null)
            yield return StartCoroutine(MoveObject(gate, gateInitialPos, moveDuration));
        yield return StartCoroutine(MoveObject(transform, plateInitialPos, moveDuration));

        isActivated = false;
    }

    IEnumerator MoveObject(Transform obj, Vector3 targetPos, float duration)
    {
        Vector3 startPos = obj.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPos;
    }
}