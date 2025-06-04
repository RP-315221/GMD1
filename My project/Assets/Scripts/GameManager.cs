using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Prefabs")]
    public GameObject explosionPrefab;
    public GameObject playerPrefab;

    [Header("UI")]
    public GameObject levelCompletePopup;  // 👈 Assign your popup here in Inspector

    [Header("Scene Progression")]
    public float continueDelay = 0.5f; // Optional delay before accepting input

    [Header("Death and Respawn Settings")]
    public Vector3 playerRespawnPosition = Vector3.zero;
    public float graceTime = 0.25f; // Adjustable delay before falling to death
    public LayerMask levelBaseLayer; // Boundry layer for level platforms

    //Other private variables
    private bool isPlayerDead = false;
    private bool levelComplete = false;
    private bool inputBlocked = false;
    private GameObject currentPlayer;
    private Coroutine fallCheckCoroutine = null;


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
        if (levelComplete && !inputBlocked)
        {
            if ((Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) ||  // A button
                (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame))      // fallback key
            {
                LoadNextScene();
            }

            // Movement cancels popup
            Vector2 moveInput =
                Gamepad.current != null ? Gamepad.current.leftStick.ReadValue() :
                (Keyboard.current != null ? new Vector2(
                    Keyboard.current.aKey.isPressed ? -1 : Keyboard.current.dKey.isPressed ? 1 : 0,
                    Keyboard.current.wKey.isPressed ? 1 : Keyboard.current.sKey.isPressed ? -1 : 0
                ) : Vector2.zero);

            if (moveInput.magnitude > 0.1f)
            {
                HideLevelCompletePopup();
            }
        }

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

    //Level Progression methods
    public void TriggerLevelComplete()
    {
        levelComplete = true;
        inputBlocked = true;
        if (levelCompletePopup != null)
            levelCompletePopup.SetActive(true);

        // Delay so player doesn't accidentally skip it immediately
        Invoke(nameof(AllowContinueInput), continueDelay);
    }
    private void AllowContinueInput() => inputBlocked = false;

    private void HideLevelCompletePopup()
    {
        if (levelCompletePopup != null)
            levelCompletePopup.SetActive(false);

        levelComplete = false;
    }
    private void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("🎉 No more levels! Maybe show credits?");
        }
    }
}