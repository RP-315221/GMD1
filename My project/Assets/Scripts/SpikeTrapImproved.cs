using System.Collections;
using UnityEngine;

public class SpikeTrapImproved : MonoBehaviour
{
    [Header("Spike Trap Settings")]
    public Animator spikeTrapAnim;      // Animator for the SpikeTrap
    public float timeOffset = 0.5f;     // Delay before starting the trap loop

    void Awake()
    {
        // Get the Animator component if not assigned
        if (spikeTrapAnim == null)
            spikeTrapAnim = GetComponent<Animator>();

        // Wait before starting to desync traps
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(timeOffset);
        StartCoroutine(OpenCloseTrap());
    }

    IEnumerator OpenCloseTrap()
    {
        while (true)
        {
            spikeTrapAnim.SetTrigger("open");
            yield return new WaitForSeconds(1f);

            spikeTrapAnim.SetTrigger("close");
            yield return new WaitForSeconds(1f);
        }
    }
}
