using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 3.0f)
            Application.LoadLevel("main");
	}
}
