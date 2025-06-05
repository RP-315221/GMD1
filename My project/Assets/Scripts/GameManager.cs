using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject explosionPrefab;
    public GameObject playerPrefab;

    [Header("Death and Respawn Settings")]
    public Vector3 playerRespawnPosition = Vector3.zero;
    public float graceTime = 0.25f; // Adjustable delay before falling to death
    public LayerMask levelBaseLayer; // Boundry layer for level platforms

    [Header("Death Message")]
    public GameObject deathPanel;

    //Other private variables
    private bool isPlayerDead = false;
    private GameObject currentPlayer;
    private Coroutine fallCheckCoroutine = null;

    public void RegisterPlayer(GameObject player)
    {
        currentPlayer = player;
    }


    private void Update()
    {
        if (isPlayerDead)
        {
            bool yPressed =
                (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame);

            bool bPressed =
                (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame);

            if (bPressed)
            {
                SceneHandler handler = FindFirstObjectByType<SceneHandler>();
                if (handler != null)
                {
                    handler.LoadScene(0);
                }
                else
                {
                    Debug.LogWarning("SceneHandler not found in scene.");
                }
            }

            if (yPressed)
            {
                // Hiding Death Message 
                TryHideDeathPanel();
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

    //Player falling death methods
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

        // Showing Death Message 
        TryShowDeathPanel();
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

    //Player dying to a trap
    public void InstantKillPlayer(GameObject player)
    {
        if (player == null || isPlayerDead || explosionPrefab == null) return;

        isPlayerDead = true;

        // Play explosion immediately
        Vector3 offsetPos = player.transform.position + Vector3.up * 1f;
        GameObject explosion = Instantiate(explosionPrefab, offsetPos, Quaternion.identity);
        Destroy(explosion, 2f);
        Destroy(player);

        // Showing Death Message 
        TryShowDeathPanel();
    }


    //Player respawn
    private void RespawnPlayer()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab not assigned!");
            return;
        }

        GameObject newPlayer = Instantiate(playerPrefab, playerRespawnPosition, Quaternion.identity);
        isPlayerDead = false;

        // Assign new player to the FollowCamera
        FollowCamera cam = Camera.main?.GetComponent<FollowCamera>();
        if (cam != null)
        {
            cam.target = newPlayer.transform;
        }
        else
        {
            Debug.LogWarning("Main camera or FollowCamera script not found!");
        }

        RegisterPlayer(newPlayer);
    }

    private void TryShowDeathPanel()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }
    }
    private void TryHideDeathPanel()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
        }
    }
}