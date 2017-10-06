using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {
	//Score system
	public Text scoreText;
	public int score;

	//Timer
	public float MaxTime = 300f;
	public int MaxTimerPoints = 1000;
	private int TimerPoints;
	private float time = 0;
	private float timeToTakePoints;
	private int PointsTaken = 0;

	public void SetScoreText(){
		scoreText.text = "Score: " + score.ToString ();
	}
	void Awake(){
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		TimerPoints = MaxTimerPoints/500;
		timeToTakePoints = MaxTime/5000;
		Debug.Log (timeToTakePoints);
		score = MaxTimerPoints;
		SetScoreText ();
	}

	void FixedUpdate(){
		time += Time.deltaTime;
		//Debug.Log (time);
		if (time >= timeToTakePoints) {
			Debug.Log (time);
			//score -= TimerPoints;
			TakePoints(TimerPoints);
			time = 0;
			SetScoreText ();
		}
	}
	void TakePoints(int take){
		if(PointsTaken<MaxTimerPoints){
			score -= take;
			PointsTaken += take;
		}
	}
}


