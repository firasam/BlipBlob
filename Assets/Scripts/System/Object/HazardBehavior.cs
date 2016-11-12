using UnityEngine;
using System.Collections;

public class HazardBehavior : ObjectBehavior {

	public bool _volatile = false;
	public bool _knockback = false;

	public override void OnContact ()
	{
		PlayerBehavior player = ContactObject.GetComponent<PlayerBehavior> ();
		if (player) {
			player.Health -= Value;
			if (_knockback) {
				player.DisableMovementControl ();
				Rigidbody2D playerRigidbody2D = player.GetComponent<Rigidbody2D> ();
				Vector2 vel = playerRigidbody2D.velocity;
				float _knockbackForce = 300f;
				playerRigidbody2D.AddForce(vel.normalized * -_knockbackForce);
				Wait (0.1f, () => {
					player.EnableMovementControl ();
					if (_volatile) Destroy (this.gameObject);
				});
			}

			if (_volatile && !_knockback) {
				Destroy (this.gameObject);
			}
		}
	}
}
