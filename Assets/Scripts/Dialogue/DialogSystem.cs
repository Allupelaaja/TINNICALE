using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour {

	public GameController gc;

	public string Name;
	public List<string> Dialogues = new List<string>();
	public List<int> TimeOnDialog = new List<int>();
	//public float TimeOnEachDialog = 3f;

	private int currentDialog = 0;
	private float timerToSwitchDialog = 0f;

	private bool speaking = false;

	void Start () {
		gc = GameObject.Find ("GameController").GetComponent<GameController>();
		//StartDialog();
	}

	public void StartDialog() {
		if(!speaking){
			speaking = true;
			gc.ShowDialogBox();
			gc.SetDialog(Name, Dialogues[currentDialog]);
		}
	}

	public void NextDialog() {
		Debug.Log ("next dialog");
		timerToSwitchDialog = 0;
		if(Dialogues.Count > currentDialog+1){
			currentDialog++;
			//dialogBox.SetDialogText(Dialogues[currentDialog]);
			gc.SetDialog(Name, Dialogues[currentDialog]);
		}
		else {
			StopDialog();
		}
	}
	
	public void StopDialog() {
		//dialogBox.HideDialogBox ();
		gc.HideDialogBox();
		currentDialog = 0;
		speaking = false;
	}

	void FixedUpdate () {
		if (speaking) {
			timerToSwitchDialog += Time.deltaTime;
			if (timerToSwitchDialog >= TimeOnDialog [currentDialog]) {
				NextDialog ();
				//timerToSwitchDialog = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("collider hit");
		if(other.transform.tag.Equals("Player")){
			Debug.Log ("hit player");
			StartDialog ();
		}
	}
}
