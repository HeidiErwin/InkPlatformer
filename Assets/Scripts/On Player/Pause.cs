﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject Canvas;
	public static bool Paused = false;

	void Start(){
		Canvas.gameObject.SetActive (false);
		Time.timeScale = 1.0f;
		Paused = false;
	}

	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if(Paused == true){
				Time.timeScale = 1.0f;
				Canvas.gameObject.SetActive (false);
				Paused = false;
			} else {
				Time.timeScale = 0.0f;
				Canvas.gameObject.SetActive (true);
				Paused = true;
			}
		}
	}
		
}
