using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float timer;

	void Update(){
		timer += 1.0f * Time.deltaTime;
		if (timer >= 5) {
			Destroy(gameObject);
		}
	}

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
	}
	void Rotate ()
	{
		transform.Rotate(Vector3.up * -90);
	}
}
