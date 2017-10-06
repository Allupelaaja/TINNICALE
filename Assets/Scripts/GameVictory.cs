using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVictory : MonoBehaviour {

	private GameObject victoryWindow;

	void OnTriggerEnter(Collider other) {
		victoryWindow.GetComponent<VictoryWindow> ().SetScore (1000000);
		Instantiate (victoryWindow, GameObject.Find("Canvas").transform);
	}
}
