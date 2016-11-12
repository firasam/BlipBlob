using UnityEngine;
using System.Collections;

public class ObjectBehavior : ExtendedBehavior {

	[SerializeField] private float value;
	private Collider2D contactObject;

	void Update () {
		if (contactObject != null) {
			OnContact ();
			contactObject = null;
		}
	}

	public float Value {
		get {
			return this.value;
		}
		set {
			this.value = value;
		}
	}

	public Collider2D ContactObject {
		get {
			return this.contactObject;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		contactObject = other;
	}

	public virtual void OnContact () {}
}
