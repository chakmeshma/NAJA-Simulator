using System.Collections;
using UnityEngine;

public class CreditsInit : MonoBehaviour
{
    private bool exitAfter = false;

    private void Start()
    {
        exitAfter = GameObject.Find("Exit Message") != null;

        if (exitAfter)
        {
            StopAllCoroutines();
            StartCoroutine(delayedExit());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;

            if (exitAfter)
            {
                Application.Quit();
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
            }
        }
    }

    private IEnumerator delayedExit()
    {
        yield return new WaitForSeconds(4);

        Application.Quit();
    }
}
