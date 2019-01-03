using UnityEngine;

public class MainMenuSceneLoader : MonoBehaviour
{
    private bool loadingInitiated = false;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= 3.0f && !loadingInitiated)
        {
            loadingInitiated = true;

            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
    }

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
