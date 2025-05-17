using UnityEngine;

public class PlayerDeathDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            GameManager.Instance.KillPlayer(gameObject);
        }
    }
}
