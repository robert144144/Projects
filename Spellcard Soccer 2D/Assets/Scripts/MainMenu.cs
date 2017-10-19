using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

		//int x = BallMovement.win;

	void PlayGame(){
		//if an up arrow is pressed after match mode is selected, score to win goes up, if down is selected it goes down.
		//win++;
		Application.LoadLevel(1);
	}

	void QuitGame(){
		Application.Quit();
	}
}