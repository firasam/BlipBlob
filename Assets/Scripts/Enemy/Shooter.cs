using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public Vector3[] angle;
	//public float radius;
	public GameObject bullet;
	private float nextTimer;
	public float timer;
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > nextTimer) {
			for (int i = 0; i < angle.Length; i++) {
				Quaternion rotation = Quaternion.Euler (angle [i]);
				Instantiate (bullet, transform.position, rotation * transform.rotation);
				nextTimer = (Time.time + timer);
			}
		}
	}
}
