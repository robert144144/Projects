/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalScore : MonoBehaviour {

	private int P1score;
	[SerializeField] private Text countText;
	[SerializeField] private Text winText;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ( "Goal 1"))
		{
			P1score = P1score + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "P1Score: " + P1score.ToString ();
		if (P1score >= 10)
		{
			winText.text = "P1 Wins!";
		}
	}
}
*/