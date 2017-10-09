using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameController : MonoBehaviour {

	private Slider musicSlider;
	private Slider effectsSlider;
	private Button applyButton;

	public GameObject dialogBox;

	void Awake () {
		FindAndSetUIControls ();
		FindSettingsForm ();
		FindDialogBox ();

		HideDialogBox ();
	}

	void OnLevelWasLoaded() {
		FindAndSetUIControls ();
		FindSettingsForm ();
		FindDialogBox ();
		HideDialogBox ();
	}

	/***** Finds current scene's UI controls and adds listeners *****/
	private void FindAndSetUIControls() {
		string currentScene = SceneManager.GetActiveScene ().name;
		Debug.Log (currentScene);
		if(currentScene.Equals("menu")){
			//Finds MainMenu buttons
			Debug.Log("MAIN");
			Button buttonStart = GameObject.Find("ButtonStart").GetComponent<Button>();
			buttonStart.onClick.AddListener (StartGame);
			Button buttonOptions = GameObject.Find("ButtonOptions").GetComponent<Button>();
			buttonOptions.onClick.AddListener (LoadAudio);
			Button buttonExit = GameObject.Find("ButtonExit").GetComponent<Button>();
			buttonExit.onClick.AddListener (QuitGame);
		} else if (currentScene.Equals("audio")) {
			//Finds Audio buttons
			Debug.Log("AUDIO");
			Button buttonBack = GameObject.Find("ButtonBack").GetComponent<Button>();
			buttonBack.onClick.AddListener (LoadMenu);
		}
	}

	/**** Finds the audio settings form ****/
	private void FindSettingsForm (){
		if (GameObject.Find ("SoundMusicSlider") != null) {
			musicSlider = GameObject.Find ("SoundMusicSlider").GetComponent<Slider> ();
			applyButton = GameObject.Find ("ApplyButton").GetComponent<Button> ();
			applyButton.onClick.AddListener (ApplySettings);
		}
	}

	/**** Find the DialogBox *****/
	private void FindDialogBox (){
		if (GameObject.Find ("DialogBox") != null) {
			dialogBox = GameObject.Find ("DialogBox");
		} else if (GameObject.Find ("DialogBox(Clone)") != null) {
			dialogBox = GameObject.Find ("DialogBox(Clone)");
		} else {
			GameObject temp = Resources.Load("Prefabs/DialogBox", typeof(GameObject)) as GameObject;
			dialogBox = Instantiate (temp, GameObject.Find("Canvas").transform);
			//dialogBox = temp.GetComponent<DialogBox> ();
		}
	}

	/**** Sets values to DialogBox****/
	public void SetDialog(string name, string dialog) {
		DialogBox db = dialogBox.GetComponent<DialogBox> ();
		db.SetDialogName (name);
		db.SetDialogText (dialog);
	}

	public void ShowDialogBox() {
		dialogBox.SetActive (true);
	}

	public void HideDialogBox() {
		dialogBox.SetActive (false);
	}

	//Scene change
	public void StartGame() {
		SceneManager.LoadScene ("test");
	}

	//Close game
	public void QuitGame() {
		Application.Quit ();
	}

	//Open audio settings
	public void LoadAudio() {
		SceneManager.LoadScene ("audio");
	}

	//Open main menu
	public void LoadMenu() {
		SceneManager.LoadScene ("menu");
	}

	//Background music
	public void ApplySettings() {
		if (musicSlider != null) {
			AudioListener.volume = musicSlider.value;
		}
	}

	//Resets timeScale
	public void resetTimeScale() {
		Time.timeScale = 1;
	}

	//Back to menu
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");
		}
	}
}