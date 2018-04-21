using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void QuitGame() {
		Debug.Log ("quit");
		Application.Quit ();
	}

    private void Update()
    {
        //open menu if ESC pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
