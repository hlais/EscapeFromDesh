using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOnHit : MonoBehaviour
{

	// for this collider that collects Objects that passes through it and destroys it.
	// On unity we must have RigidBody2D-> we set is Kinematic. AND Box Collider2D--> we set this to IsTrigger. 

	void OnTriggerEnter2D(Collider2D other)// is calling the object we collided with 
	{
		Destroy(other.gameObject); //calling Destory statment. to destroy game object
	}
}
