using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneHandler handler = FindFirstObjectByType<SceneHandler>();
            if (handler != null)
            {
                handler.TriggerLevelPassed(other.gameObject);
            }
            else
            {
                Debug.LogWarning("SceneHandler not found in scene.");
            }
        }
    }
}
