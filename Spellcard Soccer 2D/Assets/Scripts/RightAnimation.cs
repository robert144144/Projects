using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAnimation : MonoBehaviour {

	public Animator anim;

	void start (){
		anim = GetComponent<Animator>();
	}

	void Update (){
		if (Input.GetKey (KeyCode.RightArrow)) {
			anim.Play ("Right");
		}
	}
}