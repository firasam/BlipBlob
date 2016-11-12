using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StatusSystem : MonoBehaviour {

	public Text pointText;
	public Text healthText;
	public Text blobText;

	public PlayerBehavior player;

	void Update () {
		displayPoint ();
		displayHealth ();
		displayBlob ();
	}

	private void displayBlob () 
	{
		BlobBehavior blob = (BlobBehavior) player;
		string text = blob.Blobies.ToString ();
		display ("Blob", text, blobText);
	}

	private void displayPoint () 
	{
		string text = player.Point.ToString ();
		display ("Point", text, pointText);
	}

	private void displayHealth () 
	{
		string text = player.Health.ToString ();
		display ("Health", text, healthText);
	}

	private void display (string tag, string text, Text textHolder) 
	{
		if (textHolder != null) {
			textHolder.text = text;
		} else {
			Debug.Log (tag + ": " + text);
		}
	}

}
