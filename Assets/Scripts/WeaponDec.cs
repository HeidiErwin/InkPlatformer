using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDec : MonoBehaviour {

	public float Damage = 10;
	public LayerMask whatToHit;
	public GameObject inkBallPrefab;

	//float timeToFire = 0;
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
		if (InkManager.Instance.InkRemaining > 0 && !Pause.Paused) {
			if (Input.GetMouseButtonDown(0)) {
				Shoot();
				InkManager.Instance.DecrementInk();
			}
		}
	}

	void Shoot() {
		//Debug.Log ("test");
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition, 10, whatToHit);

		Effect((mousePosition - firePointPosition).normalized);
		if (hit.collider != null) {
			Debug.DrawLine(firePointPosition, hit.point, Color.red);
			//hit.collider.GetComponent<Collider2D>();
		}
	}

	void Effect(Vector2 dir) {
		//Instantiate (BulletTrailPrefab, firePoint, firePoint.rotation);
		// Vector2 p = new Vector2(firePoint.position.x, firePoint.position.y);
		// Quaternion r = new Quaternion(firePoint.rotation.x, firePoint.rotation.y, firePoint.rotation.z, firePoint.rotation.w);
		// Debug.Log("rotate " + r);
		// Debug.Log("fp rotate " + firePoint.rotation);
		Quaternion ray = new Quaternion(dir.x, dir.y, 0, 0);

		//Debug.Log(p);
		var b = (GameObject)Instantiate(inkBallPrefab, firePoint.position, ray);
		b.GetComponent<InkBallScript>().SetDirection(dir);
	}
}

