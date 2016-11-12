using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField] private PlayerBehavior player;
	private Vector3 offset;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		velocity = player.GetComponent<Rigidbody2D> ().velocity;
	}
	
	void  LateUpdate () {
		Vector3 position = Vector3.SmoothDamp (transform.position, player.transform.position + offset, ref velocity, 0.3f);
		transform.position = Vector3.ClampMagnitude(position, 3.0f);
	}
}
