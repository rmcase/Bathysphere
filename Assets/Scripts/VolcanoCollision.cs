using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VolcanoCollision : MonoBehaviour {

	private Transform player;
	private RectTransform volcano;
	private Animator animator;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		volcano = (RectTransform)transform;

		animator = GetComponent<Animator> ();

//		animator.speed = 5f;
		animator.SetFloat("multiplier", 2.0f);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void colliderOn() {
		GetComponent<BoxCollider2D> ().enabled = true;
	}

	void colliderOff() {
		GetComponent<BoxCollider2D> ().enabled = false;
	}
}
