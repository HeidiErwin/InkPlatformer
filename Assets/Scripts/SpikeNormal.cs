using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeNormal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 8) { // if colliding with player
			Player p = other.gameObject.GetComponent<Player>(); // get the Player component of our Player object
			p.Death(); // kill the player
		}
	}
}
