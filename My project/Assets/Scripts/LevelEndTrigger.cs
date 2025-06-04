using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TriggerLevelComplete();
        }
    }
}
