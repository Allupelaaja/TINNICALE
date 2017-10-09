using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVictory : MonoBehaviour {

	public GameObject victoryWindow;
	private ScoreSystem ss;

	void Start() {
		ss = GameObject.Find ("Player").GetComponent<ScoreSystem>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("qwerftgyhikol");
		if(other.tag.Equals("Player")){
			Time.timeScale = 0;
			victoryWindow.GetComponent<VictoryWindow> ().SetScore (ss.score);
			Instantiate (victoryWindow, GameObject.Find("Canvas").transform);
		}
	}
}
