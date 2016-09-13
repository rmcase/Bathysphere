using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Vector2 force, side, moveVelocity, crashVelocity;
	public bool controlsEnabled = true;

	private bool clicked, movingUp;
	private Rigidbody2D player;

	private float boostAmt = 1;
	private float boostDrain = 1.5f;
	private float boostRecharge = 2.25f;
	private bool canBoost, showBoostText;
	private Transform camera;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		GetComponent<Animator> ().speed = 1;
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;

	}

	void Update() {
		player.velocity = moveVelocity;

		movingUp = false;

		camera.position = new Vector3 (transform.position.x, camera.position.y, -1);

		if (transform.position.y < 4) {
			HandleInput ();
		}

		if (movingUp) {
			player.MoveRotation (6);

		} else {
			player.MoveRotation (-6);
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
			if (boostAmt == 1) {
				showBoostText = true;
				canBoost = true; // we're full we can boost again!
			}
			Debug.Log("Boost Finished");
		}
	}

	void Boosting() {
		
		if (canBoost && Input.GetKey (KeyCode.Space)) {
			boostAmt = Mathf.Max (0, boostAmt - Time.deltaTime / boostDrain);

			if (boostAmt == 0) {
				canBoost = false; // we ran out of juice stop boosting
			}
			player.velocity = new Vector2 (5, 0);
		} 
		else {
			boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
			if (boostAmt == 1) {
				showBoostText = true;
				canBoost = true; // we're full we can boost again!
			}
			Debug.Log("Boost Finished");
		}
	}

	void OnMouseDown() {
		clicked = true;
	}

	void OnMouseUp() {
		clicked = false;
	}

	void Up() {
		movingUp = true;
		player.AddForce (force);
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Bounds") {
			Implode ();
			Invoke ("Reset", 1.2f);
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

		if (coll.gameObject.tag == "Torpedo") {
			GetComponent<CircleCollider2D> ().enabled = false;
			moveVelocity = crashVelocity;
			Implode ();
			Invoke ("Reset", 2.8f);
		}

		if (coll.gameObject.tag == "Bounds") {
			
		}

		if (coll.gameObject.tag == "Damager") {
			moveVelocity = crashVelocity;
			GetComponent<CircleCollider2D> ().enabled = false;
			Implode ();
			Invoke ("Reset", 2.2f);
		}

		if (coll.gameObject.tag == "Mine") {
			coll.gameObject.GetComponentInParent<Animator> ().Play ("Exp");
			coll.gameObject.GetComponentInParent<AudioSource> ().enabled = true;
		}

		camera.GetComponent<Camera> ().orthographicSize = 4f;
		camera.GetComponent<Animator> ().Play ("CameraShake");


		moveVelocity = crashVelocity;
		GetComponent<CircleCollider2D> ().enabled = false;
		Implode ();
		Invoke ("Reset", 2.8f);

	}

	void Reset() {
		HUD.score = 0;
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	void Implode() {
		GetComponentInChildren<ParticleSystem> ().Stop();
		GetComponent<Animator> ().Play ("Implosion");
	}

	void OnGUI(){
		if (showBoostText) {
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "BOOST RECHARGED");

		}
	}

}
