using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public float speed;
	// Use this for initialization
	private Rigidbody2D _rb2d;
	void Start () {
		_rb2d = gameObject.gameObject.GetComponent<Rigidbody2D> ();
		_rb2d.velocity = transform.up*speed;

	}
}
