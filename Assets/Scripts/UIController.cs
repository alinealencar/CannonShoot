using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	[SerializeField]
	Text scoreLabel;

	/* This method sets the status of the UI elements in the initialization of the game.*/
	private void Initialize(){
		Player.Instance.Score = 0;
		scoreLabel.gameObject.SetActive (true);
	}

	/* This method sets the status of the UI elements when the player
	 * reaches a game over status. */
	public void GameOver(){
		//Stop the game from continuing
		Time.timeScale = 0;
	}

	/* This method updates the score label in the UI with an updated score. */
	public void UpdateScoreUI(){
		scoreLabel.text = "Points: " + Player.Instance.Score;
	}

	// Use this for initialization
	void Start () {
		//The game does not change its status. Character cannot be moved.
		Player.Instance.gCtrl = this;
		Initialize ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
