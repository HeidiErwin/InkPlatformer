using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmPlayer : MonoBehaviour {

	static BgmPlayer instance;

	void Start(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if (instance != this || SceneManager.GetActiveScene().buildIndex == 0) {
			Destroy (gameObject);
		}
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
