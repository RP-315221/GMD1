using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    void Update()
    {
        // Listen for controller 'B' button (typically "joystick button 1")
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            LoadMainMenu();
        }

        // Optional: For keyboard fallback (e.g. Esc or Backspace)
        // if (Input.GetKeyDown(KeyCode.Escape)) LoadMainMenu();
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
