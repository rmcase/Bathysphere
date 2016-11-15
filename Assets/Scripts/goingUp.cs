using UnityEngine;
using System.Collections;

public class goingUp : MonoBehaviour {

	private Rigidbody2D player;
	private bool inBusiness;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		inBusiness = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inBusiness) {
			player.GetComponentInChildren<ParticleSystem> ().Stop ();
			player.velocity = new Vector2 (0, 10);
			player.constraints = RigidbodyConstraints2D.FreezePositionX;
			player.AddForce (new Vector2 (0, 350f));
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		print ("yaya");
		inBusiness = true;
	}
}
