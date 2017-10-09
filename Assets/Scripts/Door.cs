using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float mass;
	public Rigidbody2D rb;

	/********* Sets the door as locked or unlocked ************/

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (other.GetComponent<PlayerController> ().rfid) {
				rb = GetComponent <Rigidbody2D> ();
				rb.mass = 1;
			} else {
				rb = GetComponent <Rigidbody2D> ();
				rb.mass = 10000;
			}
		}
	}
}
