using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsInit : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;

            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }
	}
}
