using UnityEngine;
using System.Collections;

public class FlyMove : MonoBehaviour {

	public bool clockwise;
	private Rigidbody2D _rb2d;
	private Transform target;
	public float rotatingSpeed;
	Vector2 targetPos ;
	public float radius;
	private bool ison=false;
	private float scaler;
	// Update is called once per frame
	void Awake(){
		transform.GetChild (0).gameObject.SetActive (false);
		Debug.Log (transform.GetChild (0).gameObject.activeInHierarchy);
		target= GameObject.FindWithTag ("Arena").GetComponent<Transform> ();
		_rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	void Start(){
		if (clockwise)
			scaler = -1.0f;
		else
			scaler = 1.0f;
		targetPos = _rb2d.position;
	}
	void FixedUpdate () {
		Vector2 pivot=target.position;
		Vector2 relativePos = new Vector2 (_rb2d.position.x - pivot.x,_rb2d.position.y - pivot.y);
		float angle = Mathf.Atan2 (relativePos.y,relativePos.x);
		if (Mathf.Abs(_rb2d.position.x - targetPos.x) < 0.01 && Mathf.Abs(_rb2d.position.y - targetPos.y) < 0.01) {
			if (ison) {
				transform.GetChild (0).gameObject.SetActive (true);
			}
			ison = true;
			float targetY = Mathf.Sin (angle-rotatingSpeed*scaler)*radius+(target.position.y);
			float targetX = Mathf.Cos (angle-rotatingSpeed*scaler)*radius+(target.position.x);
			targetPos = new Vector2 (targetX, targetY);
			_rb2d.velocity = targetPos-_rb2d.position;
		}

	}
}
