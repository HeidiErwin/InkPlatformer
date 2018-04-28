using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject Canvas;
	public static bool Paused = false;

	void Start(){
		Canvas.gameObject.SetActive (false);
	}

	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if(Paused == true){
				Debug.Log ("yes");
				Time.timeScale = 1.0f;
				Canvas.gameObject.SetActive (false);
				Paused = false;
			} else {
				Debug.Log ("no");
				Time.timeScale = 0.0f;
				Canvas.gameObject.SetActive (true);
				Paused = true;
			}
		}
	}
		
}
