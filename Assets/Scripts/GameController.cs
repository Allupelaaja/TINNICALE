using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene ("test");
	}

	public void QuitGame() {
		Application.Quit ();
		Debug.Log ("Game Exited");
	}

	public void LoadAudio() {
		SceneManager.LoadScene ("audio");
	}

	public void LoadMenu() {
		SceneManager.LoadScene ("menu");
	}
	

	// Use this for initialization
	void Start () {
		
	}

	public void LoadScene(string sceneName) {
		Application.LoadLevel (sceneName);
	}
}
