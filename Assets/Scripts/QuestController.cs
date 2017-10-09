using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour {

	private bool completed = false;

	/*********** Player cup check and rfid give ***********/

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !completed) {
			PlayerController pc = other.GetComponent<PlayerController> ();
			if (pc.cups > 0) {
				pc.cups -= 1;
				completed = true;
				pc.SetRfid(true);

				if (this.transform.GetComponent<DialogSystem> () != null) {
					DialogSystem ds = this.transform.GetComponent<DialogSystem> ();
					if (ds != null) {
						Destroy (ds);
						ds = this.gameObject.AddComponent (typeof(DialogSystem)) as DialogSystem;
						ds.Name = "Caretaker";
						ds.Dialogues.Add ("Thank you for the cup, here's the RFID-key for you.");
						ds.TimeOnDialog.Add (4);
					}
				}
			}
		}
	}
}
