using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryWindow : MonoBehaviour {
	public Text ScoreText;

	public void SetScore (int score){
		ScoreText.text = "Score: " + score;
	}

	//Resets timeScale and loads main menu
	public void BackToMainMenu() {
		SceneManager.LoadScene ("menu");
		Time.timeScale = 1;
	}
}
