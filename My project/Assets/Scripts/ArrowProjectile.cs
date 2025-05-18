using UnityEngine;
using System.Collections;

public class ArrowProjectile : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasHit = false;

    public LayerMask obstacleLayer;
    public float destroyDelay = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
    }

    public void SetVelocity(Vector3 velocity)
    {
        if (rb != null && !hasHit)
        {
            rb.linearVelocity = velocity; // 🔁 Fixed: was `linearVelocity`, which is incorrect in Unity
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;

        if (((1 << collision.gameObject.layer) & obstacleLayer) != 0)
        {
            hasHit = true;
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;

            StartCoroutine(DestroyAfterDelay());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.CompareTag("Player"))
        {
            hasHit = true;

            // Kill the player via GameManager
            GameManager.Instance.KillPlayer(other.gameObject);

            // Stop all motion and physics immediately
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            // Disable all colliders (to avoid wall collision after kill)
            foreach (var col in GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }

            // Destroy next frame (safe cleanup after physics step)
            StartCoroutine(DestroyNextFrame());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    private IEnumerator DestroyNextFrame()
    {
        yield return null; // wait one frame
        Destroy(gameObject);
    }
}
