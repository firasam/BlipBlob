using UnityEngine;
using System.Collections;

public class ShootTimer : MonoBehaviour {
	public float timer;
	public GameObject bullet;
	public Transform spawner;
	private float nextTimer;

	void FixedUpdate(){
		if (Time.time > nextTimer) {
			Instantiate (bullet, spawner.position, spawner.rotation);
			nextTimer = (Time.time + timer);
		}
	}
}
