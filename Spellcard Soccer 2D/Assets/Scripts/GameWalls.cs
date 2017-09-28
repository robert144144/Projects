using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}
/*
public class GameWalls : MonoBehaviour {

	public Boundary boundary;

	void FixedUpdate ()
{
		Rigidbody2D.position = new Vector3
		(
			Mathf.Clamp (Rigidbody2D.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (Rigidbody2D.position.y, boundary.yMin, boundary.yMax)
		);
	}
}*/