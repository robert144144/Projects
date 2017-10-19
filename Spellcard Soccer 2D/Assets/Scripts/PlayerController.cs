using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
public float speed; 

	public GameObject shot2;
	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawn2;
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
			Instantiate (shot2, shotSpawn2.position, shotSpawn2.rotation);
		}
	
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal1");
		float moveVertical = Input.GetAxis ("Vertical1");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody2D>().velocity = movement*speed;
	}
}
