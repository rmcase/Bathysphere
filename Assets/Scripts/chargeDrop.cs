﻿using UnityEngine;
using System.Collections;

public class chargeDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D> ().MoveRotation (15);
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Random.Range(-.60f, -2.2f));
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -3.75) {
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
