using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDec : MonoBehaviour {

	public float Damage = 10;
	public LayerMask whatToHit;
	public GameObject inkBallPrefab;
	Transform firePoint;

	// Use this for initialization
	void Awake() {
		firePoint = transform.Find("FirePoint");
		if (firePoint == null) {
			Debug.LogError("no fire point");
		}
	}

	// Update is called once per frame
	void Update() {
		if (InkManager.Instance.InkRemaining > 0 || !Pause.Paused) {
			if (Input.GetMouseButtonDown(0)) {
				Shoot();
				InkManager.Instance.DecrementInk();
			}
		}
	}

	void Shoot() {
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition, 10, whatToHit);

		Effect((mousePosition - firePointPosition).normalized);
	}

	void Effect(Vector2 dir) {
        //Quaternion ray = new Quaternion(dir.x, dir.y, 0, 0);
        float angleDegree = Vector2.Angle(Vector2.right, dir);

        var b = (GameObject)Instantiate(inkBallPrefab, firePoint.position, inkBallPrefab.transform.rotation);
		b.GetComponent<InkBallScript>().SetDirection(dir);
	}
}

