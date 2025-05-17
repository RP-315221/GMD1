using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Explosion Effect")]
    public GameObject explosionPrefab;

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void KillPlayer(GameObject player)
    {
        if (player == null || explosionPrefab == null)
            return;

        // Getting player's position on death
        Vector3 playerPosition = player.transform.position;

        // Ofsetting position by 1 unit in the Y direction
        Vector3 offsetPosition = new Vector3(playerPosition.x, playerPosition.y + 1f, playerPosition.z);

        // Instantiate the explosion effect at the offset position
        Instantiate(explosionPrefab, offsetPosition, Quaternion.identity);
        Destroy(player);
    }
}
