using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
	}
	void Rotate ()
	{
		transform.Rotate(Vector3.up * -90);
	}
}
