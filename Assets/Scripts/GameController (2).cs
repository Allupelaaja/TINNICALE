using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private Slider musicSlider;
	private Slider effectsSlider;
	private Button applyButton;

	void Awake () {
		FindSettingsForm ();
	}

	public void FindSettingsForm (){
		if (GameObject.Find ("SoundMusicSlider") != null) {
			musicSlider = GameObject.Find ("SoundMusicSlider").GetComponent<Slider> ();
			applyButton = GameObject.Find ("ApplyButton").GetComponent<Button> ();
			applyButton.onClick.AddListener (ApplySettings);
		}
	}

	//Scene change

	public void StartGame() {
		SceneManager.LoadScene ("test");
	}

	public void QuitGame() {
		Application.Quit ();
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

	//Background music

	public void ApplySettings() {
		if (musicSlider != null) {
			AudioListener.volume = musicSlider.value;
		}
	}

	//Back to menu

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");
		}
	}
}