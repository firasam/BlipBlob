using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlobBehavior : PlayerBehavior
{
	[SerializeField] private BlobTrail _blobber;
	private float blobies = 100.0f; 

	private Vector3 initialScale;

	void Start () {
		initialScale = transform.localScale;
	}

	public override void MoveByVelocity (Vector2 direction)
	{
		base.MoveByVelocity (direction);
		MovementAnimation (direction);
		if (_trailable) Blobbing (0.25f, 0.5f);
	}

	public float Blobies {
		get {
			return this.blobies;
		}
		set {
			blobies = value;
		}
	}


	const float _APPROX = 0.25f;
	static readonly List<Vector2> DIRECTIONS_IDX = 
		new List<Vector2> {Vector2.down, Vector2.right, Vector2.left, Vector2.up};
	static readonly int[] ANIMATION_IDX = {1, 2, 3, 8};

	private void MovementAnimation (Vector2 direction) 
	{
		direction.Normalize ();
		Animator anim = GetComponent<Animator> ();

		if (direction.Equals (Vector2.zero)) {
			anim.SetInteger ("direction", 0);
		} else {
			for (int i = 0; i < DIRECTIONS_IDX.Count; i++)
				if (Vector2.Distance (DIRECTIONS_IDX[i], direction) < _APPROX) 
					anim.SetInteger ("direction", ANIMATION_IDX[i]);
		}
	}


	bool _trailable = true;
	private void Blobbing (float init, float dest) 
	{
		_trailable = false;
		float offset = GetComponent<Collider2D> ().bounds.size.y / 2;
		Vector3 position = transform.position + Vector3.down * offset;
		BlobTrail blobber = (BlobTrail) Instantiate (_blobber, position, Quaternion.identity);
		blobber.FitSize (transform.localScale);
		blobber.Lifespan = dest;

		BlobScaling (1f, 50f);

		Wait (init, () => {
			_trailable = true;
		});
	}

	private void BlobScaling (float decrement, float limit) {
		const float HUNDRED_AF = 100.0f; 
		if (!IsIdle () && Blobies > limit) {
			transform.localScale = initialScale *  Blobies / HUNDRED_AF;
			Blobies -= decrement;
		}
	} 
}
