using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnorer : MonoBehaviour {
	//destroy shots so no overflowing
	public float timer;
	void Update(){
		timer += 1.0f * Time.deltaTime;
		if (timer >= 4) {
			Destroy(gameObject);
		}
	}
		void Start() {
		Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		}
	}