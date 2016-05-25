using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Vector2 force, side, moveVelocity, crashVelocity, volcanoVelocity;
	public bool controlsEnabled = true;

	private bool clicked, movingUp;
	private Rigidbody2D player;

	private float boostAmt = 1;
	private float boostDrain = 1.5f;
	private float boostRecharge = 3f;
	private bool canBoost;
	public Sprite sp, sp1, sp2, sp3, sp4, sp5;
	public AudioClip coin;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		GetComponent<Animator> ().speed = 1;

	}

	void Update() {
		player.velocity = moveVelocity;

		movingUp = false;

		HandleInput ();

		if (movingUp) {
			player.MoveRotation (4);

		} else {
			player.MoveRotation (-4);
		}
	}

	void HandleInput() {
		if (Input.touchSupported) {
			if (Input.touchCount == 2)
				BoostingAndroid ();
			else if (Input.touchCount == 1) {
				//movingUp = true;
				Up ();
					
			}
		} else {

			if (Input.GetMouseButton (0)) {
				//Touch anywhere
				movingUp = true;
				Up ();
			}

			if (Input.GetKey (KeyCode.Space)) {
				Debug.Log ("Boosting");
				Boosting ();
			}

		}
	}

	void BoostingAndroid() {
		if (canBoost && Input.touchCount == 2) {
			boostAmt = Mathf.Max(0, boostAmt - Time.deltaTime / boostDrain);
			GetComponent<Animator> ().speed = 2;

			if (boostAmt == 0) {
				canBoost = false; // we ran out of juice stop boosting
				GetComponent<Animator> ().speed = 1;
			}
			player.velocity = new Vector2 (5, 0);
		} else {
			boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
			if (boostAmt == 1)
				canBoost = true; // we're full we can boost again!
			Debug.Log("Boost Finished");
		}
	}

	void Boosting() {
		/*if (Time.time > time + 3f)
			player.velocity = new Vector2 (5, 0);
		else
			Debug.Log ("Boost Finished");*/
		
		if (canBoost && Input.GetKey (KeyCode.Space)) {
			boostAmt = Mathf.Max (0, boostAmt - Time.deltaTime / boostDrain);

			if (boostAmt == 0) {
				canBoost = false; // we ran out of juice stop boosting
			}
			player.velocity = new Vector2 (5, 0);
		} 
		else {
			boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
			if (boostAmt == 1)
				canBoost = true; // we're full we can boost again!
			Debug.Log("Boost Finished");
		}
	}

	void OnMouseDown() {
		clicked = true;
		//transform.GetComponent<Rigidbody2D> ().AddForce(Vector2.up * force);
	}

	void OnMouseUp() {
		clicked = false;
	}

	void Up() {
		movingUp = true;
		player.AddForce (force);
	}

	void OnTriggerEnter2D(Collider2D other) {

		SpriteRenderer sp = other.GetComponent<SpriteRenderer> ();

		if (other.gameObject.tag == "Mine" || other.gameObject.tag == "FastMine") {
			Debug.Log ("Mine Hit");


			moveVelocity = crashVelocity;

			GetComponent<CircleCollider2D> ().enabled = false;

			Implode ();

			other.GetComponent<Animator> ().Play ("Exp");

			Invoke ("Reset", 1.5f);

		}

		if (other.gameObject.tag == "Coin") {

			//add score
			HUD.addScore(100);

			AudioSource.PlayClipAtPoint(coin, transform.position);
			Destroy (other.gameObject);
		}
			

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Iceberg") {
			Debug.Log ("Iceberg Hit");

			Implode ();

			Invoke("Reset", 1.2f);

		}
			
		if (coll.gameObject.tag == "Rock") {
			Implode ();
			Invoke("Reset", 1.2f);
		}
	}

	void Reset() {
		HUD.score = 0;
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	void Implode() {
		GetComponentInChildren<ParticleSystem> ().Stop();
		GetComponent<Animator> ().Play ("Implosion");
	}
}
