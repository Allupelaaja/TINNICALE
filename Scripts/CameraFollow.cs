using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform player;
	public float zAxis = -10f;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find ("Player").transform;
		newPos = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		newPos = this.player.position;
		newPos.z = this.zAxis;
		this.transform.position = newPos;
	}
}
