using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSaver : MonoBehaviour {
	
	private static ObjectSaver os;

	void Awake(){
		DontDestroyOnLoad (this);

		if (os == null) {
			os = this;
		} else {
			DestroyObject (gameObject);
		}
	}
}