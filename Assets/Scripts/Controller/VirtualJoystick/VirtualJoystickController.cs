using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystickController : PlayerController {

	[SerializeField] private JoystickHandle handle;

	public float flexibility = 0.5f;

	private Vector2 vectorValue;

	void Start () {
		handle.ClampDistance = flexibility;
	}

	// Update is called once per frame
	void Update () {
		vectorValue = handle.GetVectorValue ();
		player.MoveByVelocity (VectorValue);
	}

	public Vector2 VectorValue {
		get {
			return this.vectorValue;
		}
	}

}
