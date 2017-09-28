using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {
	public float speed; 

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float hitbox;
	public float player;

	private float nextFire;

	void Update ()
	{
		if (Input.GetKey (KeyCode.Q) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		GetComponent<Rigidbody2D>().velocity = movement*speed;
	}
}
