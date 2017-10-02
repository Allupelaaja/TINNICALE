using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapToggle : MonoBehaviour {

	private bool MinimapVisible = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//minimap toggle
		RawImage MinimapImage = gameObject.GetComponent<RawImage> ();
		if (Input.GetKeyDown ("m")) {
			Debug.Log ("Map opened");
			if (MinimapVisible == false) {
				MinimapImage.enabled = true;
				MinimapVisible = true;
			} else {
				MinimapImage.enabled = false;
				MinimapVisible = false;
			}
		}
	}
}
