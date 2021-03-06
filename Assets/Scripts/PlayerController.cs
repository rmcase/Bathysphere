﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Vector2 force, side, moveVelocity, crashVelocity;
	public bool controlsEnabled = true;
	public GameObject theLight;
	public Transform bg;

	private bool movingUp;
	private Rigidbody2D player;

	private float boostAmt = 1;
	private float boostDrain = 1f;
	private float boostRecharge = 3f;
	private bool canBoost;
	private Transform theCamera;
	private GameObject rechargeLight;
	private Vector3 cameraPos;
	private bool camTrigger, distanceTrigger;

	// Use this for initialization
	void Start () {
//		cameraPos = theCamera.position;
		player = GetComponent<Rigidbody2D> ();
		GetComponent<Animator> ().speed = 1;
		theCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		rechargeLight = theLight;
		camTrigger = false;
		distanceTrigger = true;

		float aspect = (float)Screen.width / (float)Screen.height;

		if (aspect < 1.5f) {
			Camera.main.orthographicSize = 4.0f;
		} 

	}


	void Update() {
 		player.velocity = moveVelocity;

		movingUp = false;

		if (Vector2.Distance (transform.position, bg.position) < 10) { 
			distanceTrigger = false;
		}
		if (transform.position.x > theCamera.position.x) {
			camTrigger = true;
		}

		if (camTrigger && distanceTrigger) {
//			theCamera.position = new Vector3 (this.transform.position.x + 6.05f, theCamera.position.y, -1);
			theCamera.position = new Vector3 (this.transform.position.x, theCamera.position.y, -1);
		}

		HandleInput ();

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
					rechargeLight.SetActive (false);
				}

				if (boostAmt == 1) {
					canBoost = true; // we're full we can boost again!
					print("Boost recharged");
					rechargeLight.SetActive (true);
					rechargeLight.GetComponent<AudioSource> ().enabled = true;
					rechargeLight.GetComponent<Animator> ().Play("lightUp");
				}
			}

			if (Input.touchCount == 1) {
				movingUp = true;
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
					rechargeLight.SetActive (false);
				}

				if (boostAmt == 1) {
					canBoost = true; // we're full we can boost again!
					print("Boost Charged");
					rechargeLight.SetActive (true);
					rechargeLight.GetComponent<AudioSource> ().enabled = true;
					rechargeLight.GetComponent<Animator> ().Play ("lightUp");

				}
			}

		}
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
		HUD.saveScore (HUD.getScore());
		HUD.score = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

	void Implode() {
		GetComponentInChildren<ParticleSystem> ().Stop();

		if (HUD.getLevelAsNum() == 3) {
			GetComponent<Animator> ().Play ("darkImplosion");
		} else {
			GetComponent<Animator> ().Play ("Implosion");
		}
	}

}
