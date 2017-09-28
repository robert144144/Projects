using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSpeed : MonoBehaviour {

	public GameObject hitbox;
	public Transform Player;

	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			Instantiate (hitbox, Player.position, Player.rotation);
		}	
	}
}
