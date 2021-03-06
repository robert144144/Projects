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
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal2");
		float moveVertical = Input.GetAxis ("Vertical2"); 

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody2D>().velocity = movement*speed;
	}
}
