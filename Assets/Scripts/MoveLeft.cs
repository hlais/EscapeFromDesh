﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

	public float speed;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.position += Vector3.left * speed * Time.deltaTime; // this moves cactus to the left. its gets transforms. and moves it to left >.<!!!

	}
}

