using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	/****** Variables ******/
	//Movement
	private float offset = -90.0f;
	private Vector3 moveDirection;
	public float Speed = 12f;

	//Throwing paperplanes
	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	private float timeBetweenThrows = 2f;
	private float timeBeforeThrow = 0;

	//Inventory
	private InventoryUIController iuic;
	private int cups = 0;
	private int papers = 0;
	private bool rfid = false;

	void Awake(){
		/****** Finds the InventoryUIController or adds one *******/
		if (this.gameObject.GetComponent<InventoryUIController> () != null) {
			iuic = this.gameObject.GetComponent<InventoryUIController> ();
		} else {
			iuic = gameObject.AddComponent (typeof(InventoryUIController)) as InventoryUIController;
		}
	}

	void Start () {
		//AddPapers (1);
	}

	void Update () {
		/********* Movement and Rotation ***********/
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		moveDirection *= Speed;
		this.transform.Translate (moveDirection * Time.deltaTime, Space.World);

		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		float rotation_z = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotation_z + offset);

		/****** Throwing ********/
		if (timeBeforeThrow > 0) {
			timeBeforeThrow -= Time.deltaTime;
		}
		if (Input.GetButtonDown("Fire1") ) {
			Fire ();
		}
	}

	public void AddPapers(int papersToAdd) {
		this.papers += papersToAdd;
	}

	/****** Instantiates the paperplane and updates UI *****/
	private void Fire() {
		if (this.papers > 0 && timeBeforeThrow <= 0) {
			Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			timeBeforeThrow = timeBetweenThrows;
			this.papers--;
			iuic.SetPapersAmmount (papers);
		}
	}

	/****** Collecting items and updating UI******/
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Cup")) {
			other.gameObject.SetActive (false);
			cups++;
			iuic.SetCupsAmmount (cups);
		}
		if (other.gameObject.CompareTag ("Paper")) {
			other.gameObject.SetActive (false);
			papers++;
			iuic.SetPapersAmmount (papers);
		}
	}
}



