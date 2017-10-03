using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

	public Text DialogText;
	public Text NameText;

	void Awake() {
		//this.gameObject.SetActive (false);
	}

	public void SetDialogText(string setText) {
		DialogText.text = setText;
	}

	public void SetDialogName(string setName) {
		NameText.text = setName;
	}

	public void ShowDialogBox() {
		this.gameObject.SetActive (true);
	}

	public void HideDialogBox() {
		this.gameObject.SetActive (false);
	}
}
