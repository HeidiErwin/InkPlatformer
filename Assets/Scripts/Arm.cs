using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {

    private WeaponDec weap;

	// Use this for initialization
	void Start () {
        weap = GetComponentInParent<WeaponDec>();
	}
	
	public void ShootAnimationEnd()
    {
        weap.ShootAnimationEnd();
    }
}
