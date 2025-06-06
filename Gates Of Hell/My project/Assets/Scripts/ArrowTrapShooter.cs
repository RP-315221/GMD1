using UnityEngine;
using System.Collections;

public class ArrowTrapShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float shootInterval = 3f;
    public float arrowSpeed = 10f;
    public float verticalSpacing = 0.5f;

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            FireVolley();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void FireVolley()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = transform.position + transform.up * ((i - 1) * verticalSpacing);
            GameObject arrow = Instantiate(arrowPrefab, spawnPos, transform.rotation);
            ArrowProjectile arrowScript = arrow.GetComponent<ArrowProjectile>();
            if (arrowScript != null)
            {
                arrowScript.SetVelocity(-transform.forward * arrowSpeed);
            }
        }
    }
}
