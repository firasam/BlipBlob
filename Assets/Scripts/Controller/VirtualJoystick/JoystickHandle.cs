using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickHandle : EventTrigger {

	private float clampDistance = 0.5f;
	private Vector2 handlePosition;
	Camera GUICamera;

	public override void OnBeginDrag (PointerEventData eventData)
	{
		base.OnBeginDrag (eventData);
		GUICamera = GameObject.FindWithTag ("GUICamera").GetComponent<Camera> ();
		handlePosition = transform.position;
	}

	public override void OnDrag (PointerEventData eventData)
	{
		base.OnDrag (eventData);
		Vector2 inputPosition =  GUICamera.ScreenToWorldPoint(Input.mousePosition);
		transform.position = handlePosition + Vector2.ClampMagnitude(inputPosition - handlePosition, clampDistance);
	}

	public override void OnEndDrag (PointerEventData eventData)
	{
		base.OnEndDrag (eventData);
		ResetHandlePosition ();
	}

	public void ResetHandlePosition () {
		transform.position = handlePosition;
	}

	public float ClampDistance {
		get {
			return this.clampDistance;
		}
		set {
			clampDistance = value;
		}
	}

	public Vector2 GetVectorValue () 
	{
		Vector2 position2D = new Vector2 (transform.position.x, transform.position.y);
		if (handlePosition.Equals (Vector2.zero)) {
			handlePosition = position2D;
		}

		return position2D - handlePosition;
	}
}
