using System.Collections;
using UnityEngine;

public class MainSceneLoader : MonoBehaviour
{
    private bool loadingInitiated = false;
    public GameObject loadingGraphicsCover;

    public void load()
    {
        if (!loadingInitiated)
        {
            loadingInitiated = true;

            Application.backgroundLoadingPriority = ThreadPriority.High;

            loadingGraphicsCover.SetActive(true);

            StartCoroutine(loadMainScene());
        }
    }

    IEnumerator loadMainScene()
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
