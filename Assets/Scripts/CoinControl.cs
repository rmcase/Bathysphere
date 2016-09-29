using UnityEngine;
using System.Collections;

public class CoinControl : MonoBehaviour {

	private bool canAddScore;

	// Use this for initialization
	void Start () {
		//Ensuring the 100 points are only added once after the trigger is entered
		canAddScore = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (canAddScore) {
			if (other.tag == "Player") {
				HUD.addScore (100);
				canAddScore = false;
			}
		}

		GetComponent<AudioSource> ().enabled = true;

		GetComponent<SpriteRenderer> ().enabled = false;
		Invoke ("Destroy", .75f);
	}

	void Destroy() {
		Destroy (gameObject);
	}
}
