using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStick : MonoBehaviour {

	[SerializeField]
	private GameObject myWeaponPrefab; 
	public Animator anim;
	private float _Timer;
	private float _Cooldown;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_Timer > 0.0f)
		{
			_Timer = Mathf.Max(0.0f, _Timer - Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.Z) && _Timer <= 0.0f) {
			anim.SetBool ("Attack", true);
			_Timer = _Cooldown;
		} else {
			anim.SetBool ("Attack", false);
			_Timer = _Cooldown;
		}
	}
}