using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneHandler : MonoBehaviour
{
    [Header("UI")]
    public GameObject levelPassedPanel;

    [Header("Cooldowns")]
    public float detectionCooldown = 1f;

    private bool inputWaiting = false;
    private bool cooldownActive = false;

    private GameObject player;

    public void TriggerLevelPassed(GameObject player)
    {
        if (cooldownActive || inputWaiting) return;

        this.player = player;

        if (levelPassedPanel != null)
        {
            levelPassedPanel.SetActive(true);
            inputWaiting = true;
        }
    }


    private void Update()
    {
        if (!inputWaiting || player == null) return;

        Vector2 moveInput = Vector2.zero;

        if (Gamepad.current != null)
        {
            moveInput = Gamepad.current.leftStick.ReadValue();
        }

        // Cancel if player moves
        if (moveInput.magnitude > 0.1f)
        {
            HidePanel();
            StartCoroutine(DetectionCooldown());
            return;
        }

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Gamepad.current != null)
        {
            if (sceneIndex == 1 && Gamepad.current.buttonSouth.wasPressedThisFrame) // A for scene 1
            {
                LoadNextScene();
            }
            else if (sceneIndex == 2 && Gamepad.current.buttonWest.wasPressedThisFrame) // X for scene 2
            {
                LoadNextScene();
            }
            else if (Gamepad.current.buttonEast.wasPressedThisFrame) // B for back to start
            {
                LoadScene(0);
            }
        }
    }

    private void HidePanel()
    {
        if (levelPassedPanel != null)
        {
            levelPassedPanel.SetActive(false);
        }
        inputWaiting = false;
    }

    private void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
            HidePanel();
        }
    }

    public void LoadScene(int index)
    {
        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
            HidePanel();
        }
    }

    private System.Collections.IEnumerator DetectionCooldown()
    {
        cooldownActive = true;
        yield return new WaitForSeconds(detectionCooldown);
        cooldownActive = false;
    }
}
