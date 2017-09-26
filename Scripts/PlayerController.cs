using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	private float offset = -90.0f;
	private Vector3 moveDirection;
	public float Speed = 12f;

	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	private float timeBetweenThrows = 2f;
	private float timeBeforeThrow = 0;
	private int ammo = 0;

	void Start () {
		AddAmmo (1000);
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

	public void AddAmmo(int ammoToAdd) {
		this.ammo += ammoToAdd;
	}

	private void Fire() {
		if (this.ammo > 0 && timeBeforeThrow <= 0) {
			Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			timeBeforeThrow = timeBetweenThrows;
			this.ammo--;
		}
	}
}

