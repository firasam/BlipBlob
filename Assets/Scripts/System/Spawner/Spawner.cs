using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] spawnPoints;
	public GameObject spawnObject;
	public bool isValid;
	public int i;

	// Use this for initialization
	void Start () {
		isValid = true;
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isValid) {
			StartCoroutine (spawnTimer());
		}
	}

	IEnumerator spawnTimer(){
		isValid = false;
		yield return new WaitForSeconds (1);

		i = Random.Range (-1, spawnPoints.Length);
		if (i == -1) {
			i = 0;
		}
		if (i == spawnPoints.Length) {
			i = spawnPoints.Length - 1;
		}

		Instantiate (spawnObject, new Vector3 (spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, 0), Quaternion.identity);

		isValid = true;
	}
}
