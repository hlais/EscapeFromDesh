using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D myRigidBody; // firstly we declare the RigidBody
	public float JumpForce;

	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D>(); // no we are Getting the componet. and assigning it to myRigidBody variable 
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Jump")) //"Jump" is the standard unity definition
		{
			myRigidBody.AddForce(transform.up * JumpForce); //adding force. Transform UP. I made a public variable
			
		}
	}
}
