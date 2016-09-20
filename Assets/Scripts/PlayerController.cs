using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Vector2 force, side, moveVelocity, crashVelocity;
	public bool controlsEnabled = true;

	private bool movingUp;
	private Rigidbody2D player;

	private float boostAmt = 1;
	private float boostDrain = 1.5f;
	private float boostRecharge = 3f;
	private bool canBoost;
	private Transform theCamera;
	private GameObject rechargeText;
	private Vector3 cameraPos;

	// Use this for initialization
	void Start () {
//		cameraPos = theCamera.position;
		player = GetComponent<Rigidbody2D> ();
		GetComponent<Animator> ().speed = 1;
		theCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		rechargeText = GameObject.FindGameObjectWithTag ("ChargeText");

	}


	void Update() {
 		player.velocity = moveVelocity;

		movingUp = false;

		theCamera.position = new Vector3 (transform.position.x, theCamera.position.y, -1);

		if (transform.position.y < 4.5f) {
			HandleInput ();
		}

		if (movingUp) {
			player.MoveRotation (5.25f);

		} else {
			player.MoveRotation (-5.5f);
		}
	}

	void HandleInput() {
		if (Input.touchSupported) {
			if (canBoost) {
				
				if (Input.touchCount == 2) {
					boostAmt = Mathf.Max (0, boostAmt - Time.deltaTime / boostDrain);
					player.velocity = new Vector2 (5.5f, 0);
					GetComponent<Animator> ().speed = 2;

					if (boostAmt == 0) {
						canBoost = false;
						GetComponent<Animator> ().speed = 1;
					}
					//				BoostingAndroid ();
				}
			} else {
				boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
				if (boostAmt != 1) {
					rechargeText.GetComponent<MeshRenderer> ().enabled = false;
				}

				if (boostAmt == 1) {
					canBoost = true; // we're full we can boost again!
					print("Boost recharged");

					StartCoroutine (chargeTextOff ());
				}
			}

			if (Input.touchCount == 1) {
				//movingUp = true;
				Up ();
					
			}
		} else {

			if (Input.GetMouseButton (0)) {
				//Touch anywhere
				movingUp = true;
				Up ();
			}

			if (canBoost) {
				
				if (Input.GetKey (KeyCode.Space)) {
					boostAmt = Mathf.Max (0, boostAmt - Time.deltaTime / boostDrain);
					player.velocity = new Vector2 (5.5f, 0);
					GetComponent<Animator> ().speed = 2;

					if (boostAmt == 0) {
						canBoost = false;
						GetComponent<Animator> ().speed = 1;
					}
	//				Boosting ();
				}
			} else {
				boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
				if (boostAmt != 1) {
					rechargeText.GetComponent<MeshRenderer> ().enabled = false;
				}

				if (boostAmt == 1) {
					canBoost = true; // we're full we can boost again!
					print("Charged" + Time.time);

					StartCoroutine (chargeTextOff ());

				}
			}

		}
	}

	IEnumerator chargeTextOff() {
//		rechargeText.GetComponent<MeshRenderer> ().enabled = true;
//		rechargeText.GetComponent<MeshRenderer> ().enabled = false;
		rechargeText.GetComponent<MeshRenderer> ().enabled = true;

		yield return new WaitForSeconds (1);

		rechargeText.GetComponent<MeshRenderer> ().enabled = false;
	}

//	void BoostingAndroid() {
//		if (canBoost && Input.touchCount == 2) {
//			boostAmt = Mathf.Max(0, boostAmt - Time.deltaTime / boostDrain);
//			GetComponent<Animator> ().speed = 2;
//
//			if (boostAmt == 0) {
//				canBoost = false; // we ran out of juice stop boosting
//				GetComponent<Animator> ().speed = 1;
//			}
//			player.velocity = new Vector2 (5.5f, 0);
//		} else {
//			boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
//			if (boostAmt == 1) {
//				canBoost = true; // we're full we can boost again!
//			}
//			Debug.Log("Boost Finished");
//		}
//	}
//
//	void Boosting() {
//		
//		if (canBoost && Input.GetKey (KeyCode.Space)) {
//			boostAmt = Mathf.Max (0, boostAmt - Time.deltaTime / boostDrain);
//
//			if (boostAmt == 0) {
//				canBoost = false; // we ran out of juice stop boosting
//			}
//			player.velocity = new Vector2 (5.5f, 0);
//		} 
//		else {
//			boostAmt = Mathf.Min(1, boostAmt + Time.deltaTime / boostRecharge);
//			if (boostAmt == 1) {
//				canBoost = true; // we're full we can boost again!
//			}
//			Debug.Log("Boost Finished");
//		}
//	}

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

		if (coll.gameObject.tag == "EditorOnly") {
			return;
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

		theCamera.GetComponent<Camera> ().orthographicSize = 4f;
		theCamera.GetComponent<Animator> ().Play ("CameraShake");


		moveVelocity = crashVelocity;
		GetComponent<CircleCollider2D> ().enabled = false;
		Implode ();
		Invoke ("Reset", 2.8f);

	}

	void Reset() {
		HUD.score = 0;
		HUD.saveScore (HUD.getScore());
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

	void Implode() {
		GetComponentInChildren<ParticleSystem> ().Stop();
		GetComponent<Animator> ().Play ("Implosion");
	}

}
