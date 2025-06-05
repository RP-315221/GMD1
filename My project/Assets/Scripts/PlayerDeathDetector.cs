using UnityEngine;

public class PlayerDeathDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.InstantKillPlayer(gameObject);
            }
            else
            {
                Debug.LogWarning("⚠ GameManager not found in scene!");
            }
        }
    }
}
