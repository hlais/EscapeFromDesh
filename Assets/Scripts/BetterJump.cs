using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

	public float fallMultiplier = 2.5f; //gravity when player is falling down //(Enhanced jumping mechanics)
	public float lowJumpMultiplier = 2f; //(Enhanced jumping mechanics) 

	Rigidbody2D rb; 

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>(); //(Enhanced jumping mechanics) 
	}

	void Update()
	{
		if (rb.velocity.y < 0)// bascially when we are falling //(Enhanced jumping mechanics)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}//gravity is the standard unity gravity that is on File setting. the -1 is encounting the giving physics gravity. //(Enhanced jumping mechanics)
	}
}
