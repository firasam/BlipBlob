using UnityEngine;
using System.Collections;

public class CollectableBehavior : ObjectBehavior {

	public override void OnContact ()
	{
		PlayerBehavior player = ContactObject.GetComponent<PlayerBehavior> ();
		if (player) {
			player.Point += Value;
			Destroy (this.gameObject);
		}
	}
}
