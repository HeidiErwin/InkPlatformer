﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int level) {
		Debug.Log ("ahhhhhhhhhhhhh");
		Application.LoadLevel (level);
		// change to scenemanager.loadscene(level)???
	}
}
