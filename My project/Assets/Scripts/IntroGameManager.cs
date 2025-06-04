using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour
{
    [Header("Scene Transition")]
    public float delayBeforeAllowingInput = 2f; // Optional: prevent accidental skip
    private bool inputAllowed = false;

    private void Start()
    {
        // Wait a short moment before allowing input
        Invoke(nameof(EnableInput), delayBeforeAllowingInput);
    }

    private void EnableInput()
    {
        inputAllowed = true;
    }

    private void Update()
    {
        if (!inputAllowed) return;

        // Gamepad A or Keyboard Enter
        bool aPressed =
            (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) ||
            (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame);

        if (aPressed)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("🟡 No next scene found. End of build settings?");
        }
    }
}
