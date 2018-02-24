using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public int moveSpeed = 10;
	Vector3 direction;
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3 (0, 1, 0);
		transform.Translate (v * Time.deltaTime * moveSpeed);
	}

	void setDirection(Vector2 dir) {
		direction = new Vector3(dir.x, dir.y, 0);
	}
}
