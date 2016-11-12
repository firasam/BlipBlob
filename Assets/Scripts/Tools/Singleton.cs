using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

	public static Singleton instance;

	public static Singleton Instance {get {return instance;} }

	void Awake () {
		if (instance != null && instance != null) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
