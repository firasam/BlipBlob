using UnityEngine;
using System.Collections;

public class GroundBehavior : MonoBehaviour {

	void OnTriggerExit2D (Collider2D other) {
		PlayerBehavior player = other.GetComponent<PlayerBehavior> ();
		if (player != null) {
			player.transform.position = Vector2.zero;
		}
	}
}
