using UnityEngine;
using System.Collections;

public class chargeDrop : MonoBehaviour {

	public float destroyHeight;

	private bool canDrop;

	// Use this for initialization
	void Start () {
		canDrop = true;

		this.GetComponent<Rigidbody2D> ().MoveRotation (15);
//		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(-.85f, -2.2f));
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, transform.position) < 10) {
			if (canDrop) {
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, Random.Range (-.85f, -2.2f));
				canDrop = false;
			}
		}

		if (transform.position.y < destroyHeight) {
			GetComponentInChildren<ParticleSystem> ().Stop ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		GetComponent<Animator> ().Play ("Explode");

		Invoke ("Destroy", .75f);

	}

	void Destroy() {
		Destroy (gameObject);
	}
}
