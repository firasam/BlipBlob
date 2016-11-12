using UnityEngine;
using System.Collections;

public class BlobTrail : ExtendedBehavior 
{
	[SerializeField] private float scale = 0.5f;
	private float lifespan = 0.5f; 

	private Vector3 initialScale;

	void Start () {
		initialScale = transform.localScale;
		Wait (lifespan, () => {
			Destroy (this.gameObject);
		});
	}

	void Update () {
		const float THISNUMBERISGOOD = 11.5f;
		Vector3 decVector = initialScale * Mathf.Pow (Lifespan, Lifespan * THISNUMBERISGOOD); 
		if (transform.localScale.x > 0.001f)
			transform.localScale -= decVector;
	}

	public float Lifespan {
		get {
			return this.lifespan;
		}
		set {
			lifespan = value;
		}
	}

	public void FitSize (Vector3 size) {
		transform.localScale = new Vector3 (size.x * scale, size.y * scale, 0);
		initialScale = transform.localScale;
	}
}
