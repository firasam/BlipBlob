using UnityEngine;
using System.Collections;

public class LockOn : MonoBehaviour {

	private Transform player;

	void Start(){
		player = GameObject.Find ("Blob").GetComponent<Transform>();
	}
	// Update is called once per frame
	void Update () {
		Vector2 target = player.position;
		Vector2 relativePos = new Vector2 (transform.position.x - target.x,transform.position.y - target.y);
		float angle = Mathf.Atan2 (relativePos.y,relativePos.x);
		Debug.Log (angle * Mathf.Rad2Deg);
		transform.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg+90);
	}
}
