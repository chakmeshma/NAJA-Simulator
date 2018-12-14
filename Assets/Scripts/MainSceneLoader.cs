using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneLoader : MonoBehaviour {
    private bool loadingInitiated = false;
    public GameObject splashLogo;
    public GameObject loadingGraphics;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 3.0f && !loadingInitiated)
        {
            loadingInitiated = true;

            Application.backgroundLoadingPriority = ThreadPriority.High;

            DontDestroyOnLoad(splashLogo.transform.parent.gameObject);

            splashLogo.SetActive(false);
            loadingGraphics.SetActive(true);

            StartCoroutine(loadMainScene());
        }
	}

    IEnumerator loadMainScene()
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("main");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
