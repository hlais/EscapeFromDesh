using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSpawner : MonoBehaviour {

	private float nextSpawn = 0;
	public Transform prefabToSpawn;
	public float spawnRate = 1;
	public float randomDelay = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextSpawn) // if time is more than the next spawn we will spawn
		{
			Instantiate(prefabToSpawn, transform.position, Quaternion.identity); // for instantiate we needed these codes. We can check unity script "Instantiate" to find out how to use these.
			nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
		}	
	}
}
