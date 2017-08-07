using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSpawner : MonoBehaviour {

	private float nextSpawn = 0;
	public Transform prefabToSpawn;
	//public float spawnRate = 1; //(comment this out. REPLACING with curbePOS. Difficult progressively gets difficult )
	//public float randomDelay = 1; //(comment this out. REPLACING with curbePOS. Difficult progressively gets difficult )
	public AnimationCurve spawnCurve;//this unlock a public option in unity. and we can adjust the curve via unity on graph! to make cactus speed up slowly
	public float curveLengthInSeconds = 30f; // this would pop on unity. making the lenght on the cuve over the 30 sec period
	private float startTime;//to figure out how much time has past. so we can work with curbeLenghtINsecs. CactusSpawn
							// Use this for initialization
	public float jitter = 0.25f; // this will random the curve 
	void Start () {
		startTime = Time.time; //lets us know how much time
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextSpawn) // if time is more than the next spawn we will spawn
		{
			Instantiate(prefabToSpawn, transform.position, Quaternion.identity); // for instantiate we needed these codes. We can check unity script "Instantiate" to find out how to use these.
																				 //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);// we are getting rid of this code and replacing it animationcurve one. to progressivly increase difficultly

			float curvePos = (Time.time - startTime) / curveLengthInSeconds; // gets value between 0 -1 / curveLengthInSeconds, this would give ous a position on the curve. 0-1. and we want to capt when it gets to one

			if (curvePos > 1f) // when we go past the edge of graph
			{
				curvePos = 1f; // it will hit this point
				startTime = Time.time; // this will reset the start time. 
			}

			nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-jitter,jitter); //evalutates the curvbe. curvePos looks at value between 0-1  // random value between 0.25 1.25 
		}	
	}
}
