using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStick : MonoBehaviour {

	[SerializeField]
	private GameObject myWeaponPrefab; 
	public Animator anim;
	private float _Timer;
	[SerializeField]
	private float _Cooldown;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.Z)) {
			anim.SetBool ("Attack", true);
		} else {
			anim.SetBool ("Attack", false);
		}
	}
}