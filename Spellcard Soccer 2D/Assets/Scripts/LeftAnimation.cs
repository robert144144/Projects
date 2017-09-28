using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAnimation : MonoBehaviour {

	public AnimationClip anim;

	private Animation _animation;

	void Start (){
		_animation = GetComponent<Animation>();
	}

	void Update (){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			// anim.Play ("Left");
			_animation.clip = anim;
		}
	}
}