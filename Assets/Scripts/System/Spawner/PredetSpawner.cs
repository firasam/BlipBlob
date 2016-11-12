using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PredetSpawner : MonoBehaviour {
	public GameObject[] spawnpoints;
	public List<spawnObject> spawnobjects = new List<spawnObject>();
	public GameObject object1;
	public int[] spots;
	public bool isValid;
	public int i;
	public int j;
	public int points;
	public float time;
	// Use this for initialization
	void Start () {
		//buat instruksimu disini!
		spawnObject s01 = new spawnObject (0.2f,new int[]{0,2},object1);
		spawnObject s02 = new spawnObject (2.0f,new int[]{0,2},object1);
		for (int x = 0; x < 4; x++) {
			spawnobjects.Add (s01);
		}
		spawnobjects.Add (s02);
		isValid = true;
		i = 0;
		j = 0;
		time = spawnobjects [0].getTime();
		//spawn hanya 1x, kan predet tidak random (kecuali kalau mau di loop)
		//StartCoroutine (spawnTimer());
	}
	
	// Update is called once per frame
	void Update () {
		//kalau spawn mau di loop, nyalakan isValid di fungsi spawnTimer()
		if (isValid) {
			StartCoroutine (spawnTimer());
		}
	}

	IEnumerator spawnTimer(){
		isValid = false;
		while (i < spawnobjects.Count) {
			j = 0;
			time = spawnobjects [i].getTime();
			spots = spawnobjects [i].getSpots ();
			while (j < spots.Length) {
				points = spots [j];
				Instantiate (spawnobjects[i].getSpawnee(), new Vector3 (spawnpoints[points].transform.position.x, spawnpoints[points].transform.position.y, 0), Quaternion.identity);
				j++;
			}
			yield return new WaitForSeconds (time);
			i++;
		}
		i = 0;
		isValid = true;
	}


}
//Instruction set, time = interval buat spawn berikutnya, spots dia mau spawn dimana aja (bisa parallel spawn, spawnee object yg mau di spawn
public class spawnObject{
	public float time;
	public int[] spots;
	public GameObject spawnee;
	public spawnObject(float time, int[] spots, GameObject spawnee){
		this.time = time;
		this.spots = spots;
		this.spawnee = spawnee;
	}

	public float getTime(){
		return time;
	}

	public int[] getSpots(){
		return spots;
	}

	public GameObject getSpawnee(){
		return spawnee;
	}
}


