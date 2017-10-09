using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 10f;
	private float timeToDestroy = 5f;
	private Vector3 direction;
	private float time;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		this.direction = this.transform.up;
		this.rb = this.gameObject.GetComponent <Rigidbody2D> ();
	}

	private void destroyBullet() {
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log ("destroyed");
		if (!col.gameObject.tag.Equals ("Bullet")) {
			destroyBullet ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.time += Time.deltaTime;
		//this.transform.Translate (direction * Time.deltaTime * speed);
		this.rb.AddForce (this.direction * this.speed);
		if (this.time >= this.timeToDestroy) {
			destroyBullet ();
		}
	}
}
