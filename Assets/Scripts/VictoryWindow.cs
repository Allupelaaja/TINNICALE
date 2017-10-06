using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryWindow : MonoBehaviour {
	public Text ScoreText;

	public void SetScore (int score){
		ScoreText.text = "Score: " + score;
	}
}
