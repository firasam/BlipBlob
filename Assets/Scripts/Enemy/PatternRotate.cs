using UnityEngine;
using System.Collections;

public class PatternRotate : MonoBehaviour {

	public Vector3 rotater;
	void Update () {
		transform.Rotate (rotater * Time.deltaTime);
	}
}
