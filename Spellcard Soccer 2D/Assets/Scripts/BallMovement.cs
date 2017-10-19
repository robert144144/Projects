using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {

	[SerializeField] private Text countText1;
	[SerializeField] private Text countText2;
	[SerializeField] private Text winText1;
	[SerializeField] private Text winText2;
	[SerializeField] private GameObject Reset; 
	[SerializeField] private GameObject ballTP;
	[SerializeField] private int win;
	[SerializeField] private Transform tpLoc;
	[SerializeField] private Transform tpLoc2;
	[SerializeField] private Transform tpLoc3;
	[SerializeField] private Transform tpLoc4;
	[SerializeField] private Transform tpLoc5;
	[SerializeField] private GameObject wall1;
	[SerializeField] private GameObject wall2;
	[SerializeField] private GameObject player1;
	[SerializeField] private GameObject player2;
	[SerializeField] private float mass;
	[SerializeField] private float mass2;
	[SerializeField] private Rigidbody2D rb;
		
	//functions capital, variables lowercase.
	private int P1score;
	private int P2score;
	private Rigidbody2D rb2d;
	private Vector2 vel;
	private Rigidbody2D rigi; 
	private Vector2 vel2;

	void GoBall(){
		float rand = Random.Range(0, 2);
		if(rand < 1){
			rb2d.AddForce(new Vector2(20, -15));
		} else {
			rb2d.AddForce(new Vector2(-20, -15));
		}
	}
		
	void Start () {
		rigi = GetComponent<Rigidbody2D>();
		Reset.SetActive (false);
		wall1.SetActive (false);
		wall2.SetActive (false);
		P1score = 0;
		P2score = 0;
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("GoBall", 3);
	}

	//void is like a function
	void ResetBall(){
		vel = Vector2.zero;
		rb2d.velocity = vel;
		transform.position = Vector2.zero;
	}
		
	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.collider.CompareTag("Player")){
			vel.x = rb2d.velocity.x;
			vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
			rb2d.velocity = vel;
		}
	}

	//code for if the ball collides with the goal then increase score by 1
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Goal 1"))
		{
			P1score++;
			SetCountText ();
			vel2 = Vector2.zero;
			rigi.velocity = vel2;
			Setball ();
		}
		if (other.gameObject.CompareTag ("Goal 2"))
		{
			P2score++;
			SetCountText ();
			vel2 = Vector2.zero;
			rigi.velocity = vel2;
			Setball ();
		}
	}

	//if the score is the value for win then display the winner
	void SetCountText ()
	{
		countText1.text = P1score.ToString() + " -";
		countText2.text = "- " + P2score.ToString ();
		if (P1score == win)
		{
			winText1.text = "Red Wins!";
		}
		if (P2score == win) {
			winText2.text = "Blue Wins!";
		}
	}

	//returns ball to start
	void Setball ()
	{	
		rb = GetComponent<Rigidbody2D> ();
		rb.mass = mass;

			float rand2 = Random.Range (0, 3);
			if (rand2 == 0) {
				ballTP.transform.position = tpLoc.transform.position;
			}
			if (rand2 == 1) {
				ballTP.transform.position = tpLoc2.transform.position;
			}
			if (rand2 == 2) {
				ballTP.transform.position = tpLoc3.transform.position;
			}
		wall1.SetActive (true);
		wall2.SetActive (true);
		Invoke("MoveBall", 3);

	//moves the players back to their starting points
		player1.transform.position = tpLoc4.transform.position;

		player2.transform.position = tpLoc5.transform.position;
	}

	//new force to ball
	void MoveBall ()
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.mass = mass2;

		wall1.SetActive (false);
		wall2.SetActive (false);
		float rand = Random.Range (0, 4);
		if (rand == 0) {
			rb2d.AddForce (new Vector2 (20, -15));
		} 
		if (rand == 1) {
			rb2d.AddForce (new Vector2 (-20, -15));
		} 
		if (rand == 2) {
			rb2d.AddForce (new Vector2 (20, 15));
		} 
		if (rand == 3) { 
			rb2d.AddForce (new Vector2 (-20, 15));
		}
	}
}