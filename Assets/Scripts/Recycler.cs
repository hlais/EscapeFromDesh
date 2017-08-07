using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour {
	public Transform startPoint; //we use transform since we are using game object/ the grass
	public Transform endPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < endPoint.position.x) // tranform the grass. is less than the end.Point. we will reset position to the code below
		{
			float gap = endPoint.position.x - transform.position.x;//this calculates the gap/ this gives us the end point and where the point has moved too 
			transform.position = new Vector3(startPoint.position.x - gap, transform.position.y, transform.position.z); // maintaing the transform position of x,y,x,
		}
		
	}
}
