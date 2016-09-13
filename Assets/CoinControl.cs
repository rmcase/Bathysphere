using UnityEngine;
using System.Collections;

public class CoinControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		HUD.addScore (100);

		GetComponent<AudioSource> ().enabled = true;

		GetComponent<SpriteRenderer> ().enabled = false;
		Invoke ("Destroy", 1f);
	}

	void Destroy() {
		Destroy (gameObject);
	}
}
