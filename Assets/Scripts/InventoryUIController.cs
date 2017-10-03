using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour {
	private Text paperText;
	private Text cupText;

	/*public int papers;
	public int cups;
	public bool rfid;*/

	void Awake(){
		paperText = GameObject.Find ("PaperText").GetComponent<Text> ();
		cupText = GameObject.Find ("CupText").GetComponent<Text> ();
	}

	public void SetPapersAmmount (int papers){
		paperText.text = "x " + papers;
	}
	public void SetCupsAmmount (int cups){
		cupText.text = "x " + cups;
	}
}