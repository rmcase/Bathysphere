using UnityEngine;
using System.Collections;

public class CoinControl : MonoBehaviour {

	private bool thisSucks;

	// Use this for initialization
	void Start () {
		thisSucks = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (thisSucks) {
			HUD.addScore (100);
			thisSucks = false;
		}

		GetComponent<AudioSource> ().enabled = true;

		GetComponent<SpriteRenderer> ().enabled = false;
		Invoke ("Destroy", .75f);
	}

	void Destroy() {
		Destroy (gameObject);
	}
}
