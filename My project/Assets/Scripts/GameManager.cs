
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Prefabs")]
    public GameObject explosionPrefab;
    public GameObject playerPrefab;

    private bool isPlayerDead = false;
    public LayerMask levelBaseLayer; // Boundry layer for level platforms
    private GameObject currentPlayer;

    private Coroutine fallCheckCoroutine = null;
    public float graceTime = 0.25f; // Adjustable delay before falling to death

    [Header("Respawn Settings")]
    public Vector3 playerRespawnPosition = Vector3.zero;


    public void RegisterPlayer(GameObject player)
    {
        currentPlayer = player;
    }

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

    private void Update()
    {
        if (isPlayerDead)
        {
            bool yPressed =
                (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame) ||
                (Keyboard.current != null && Keyboard.current.yKey.wasPressedThisFrame);

            if (yPressed)
            {
                RespawnPlayer();
            }
            return;
        }

        if (currentPlayer == null) return;

        // Raycast downward to detect platform
        Vector3 rayOrigin = currentPlayer.transform.position + Vector3.up * 0.25f;
        Ray ray = new Ray(rayOrigin, Vector3.down);

        bool isOnLevelBase = Physics.Raycast(ray, out RaycastHit hit, 2f, levelBaseLayer);
        Debug.DrawRay(rayOrigin, Vector3.down * 2f, isOnLevelBase ? Color.green : Color.red);

        if (!isOnLevelBase && fallCheckCoroutine == null)
        {
            fallCheckCoroutine = StartCoroutine(GracePeriodFallCheck());
        }
        else if (isOnLevelBase && fallCheckCoroutine != null)
        {
            StopCoroutine(fallCheckCoroutine);
            fallCheckCoroutine = null;
        }
    }
    private IEnumerator GracePeriodFallCheck()
    {
        yield return new WaitForSeconds(graceTime);

        // Check again before killing (in case player returned to level)
        Vector3 rayOrigin = currentPlayer.transform.position + Vector3.up * 0.25f;
        if (!Physics.Raycast(rayOrigin, Vector3.down, 2f, levelBaseLayer))
        {
            KillPlayer(currentPlayer);
        }

        fallCheckCoroutine = null; // Clean up reference
    }

    public void KillPlayer(GameObject player)
    {
        if (player == null || explosionPrefab == null) return;

        isPlayerDead = true;

        // Disable movement scripts
        var movement = player.GetComponent<EyeballMovement>();
        if (movement != null) movement.enabled = false;

        var floating = player.GetComponentInChildren<EyeballFloat>();
        if (floating != null) floating.enabled = false;

        // Start manual fall and destroy sequence
        StartCoroutine(FallThenExplode(player));
    }
    public void InstantKillPlayer(GameObject player)
    {
        if (player == null || isPlayerDead || explosionPrefab == null) return;

        isPlayerDead = true;
        
        // Play explosion immediately
        Vector3 offsetPos = player.transform.position + Vector3.up * 1f;
        GameObject explosion = Instantiate(explosionPrefab, offsetPos, Quaternion.identity);
        Destroy(explosion, 2f);
        Destroy(player);
    }


    private IEnumerator FallThenExplode(GameObject player)
    {
        float fallDuration = 0.5f;
        float fallSpeed = 5f;
        float elapsed = 0f;

        while (elapsed < fallDuration && player != null)
        {
            player.transform.position -= Vector3.up * fallSpeed * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (player != null)
        {
            Vector3 offsetPos = player.transform.position + Vector3.up * 1f;
            GameObject explosion = Instantiate(explosionPrefab, offsetPos, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(player);
        }
    }

    private void RespawnPlayer()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab not assigned!");
            return;
        }

        GameObject newPlayer = Instantiate(playerPrefab, playerRespawnPosition, Quaternion.identity);
        isPlayerDead = false;

        // ✅ Assign new player to the FollowCamera
        FollowCamera cam = Camera.main?.GetComponent<FollowCamera>();
        if (cam != null)
        {
            cam.target = newPlayer.transform;
        }
        else
        {
            Debug.LogWarning("Main camera or FollowCamera script not found!");
        }

        // Optional: re-register new player
        RegisterPlayer(newPlayer);
    }
}