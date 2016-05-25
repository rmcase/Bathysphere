using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour {

	void Start() {
		if (gameObject.tag == "FastMine")
			GetComponent<Animator> ().speed = 1.25f;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
