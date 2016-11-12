using UnityEngine;
using System.Collections;

public class PlayerBehavior : ExtendedBehavior {

	public float speed = 1.0f;

	protected float point = 0;
	protected float health = 100.0f;

	public float Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}

	public float Point {
		get {
			return this.point;
		}
		set {
			point = value;
		}
	}

	private bool _controlable = false;
	public virtual void MoveByVelocity (Vector2 direction) 
	{
		if (!_controlable) {
			Vector2 normalizedDirection = direction.normalized;
			GetComponent<Rigidbody2D> ().velocity = normalizedDirection * speed;
		}
	}

	public void DisableMovementControl () {
		_controlable = true;
	}


	public void EnableMovementControl () {
		_controlable = false;
	}

	public bool IsIdle () {
		return GetComponent<Rigidbody2D> ().velocity.Equals (Vector2.zero);
	} 
}
