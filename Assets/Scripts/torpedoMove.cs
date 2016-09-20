using UnityEngine;
using System.Collections;

public class torpedoMove : MonoBehaviour {

	public AudioClip explosion;

	private AudioSource audioSource;
	private bool soundPlayed;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
//		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-velocity, 0);
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-(Random.Range(5.75f, 8.25f)), Random.Range(-.15f, .15f));
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, transform.position) < 8) {
			GetComponent<AudioSource> ().enabled = true;
		}

		if (torpedoIsBehindPlayer()) {
			if (!audioSource.isPlaying) {
				audioSource.PlayOneShot (explosion);
			}
			GetComponent<Animator> ().Play ("Explode");
			Invoke ("Destroy", 1.2f);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		GetComponentInChildren<ParticleSystem> ().Stop ();
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -1);
		audioSource.clip = explosion;
		audioSource.Play ();
		GetComponent<Animator> ().Play ("Explode");
	}

	void Destroy() {
		Destroy (gameObject);
	}

	bool torpedoIsBehindPlayer() {
		bool retval = false;

		if (transform.position.x < GameObject.FindGameObjectWithTag ("Player").transform.position.x - 3.0f) {
			retval = true;
		}

		return retval;
	}
}


