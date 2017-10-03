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

	private DialogBox dialogBox;

	void Awake () {
		FindSettingsForm ();

		/**** Find the DialogBox *****/
		if (GameObject.Find ("DialogBox")) {
			dialogBox = GameObject.Find ("DialogBox").GetComponent<DialogBox> ();
		} else {
			GameObject temp = Instantiate (AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/DialogBox.prefab") as GameObject);
			dialogBox = temp.GetComponent<DialogBox> ();
		}
		HideDialogBox ();
	}

	/**** Finds the audio settings form ****/
	public void FindSettingsForm (){
		if (GameObject.Find ("SoundMusicSlider") != null) {
			musicSlider = GameObject.Find ("SoundMusicSlider").GetComponent<Slider> ();
			applyButton = GameObject.Find ("ApplyButton").GetComponent<Button> ();
			applyButton.onClick.AddListener (ApplySettings);
		}
	}

	/**** Sets values to DialogBox****/
	public void SetDialog(string name, string dialog) {
		dialogBox.SetDialogName (name);
		dialogBox.SetDialogText (dialog);
	}

	public void ShowDialogBox() {
		dialogBox.gameObject.SetActive (true);
	}

	public void HideDialogBox() {
		dialogBox.gameObject.SetActive (false);
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

	//Back to menu
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");
		}
	}
}