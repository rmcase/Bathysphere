using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VolcanoCollision : MonoBehaviour {

	private Transform player;
	private RectTransform volcano;
	private float width;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		volcano = (RectTransform)transform;
		width = volcano.rect.width / 2;

		GetComponent<Animator> ().speed = Random.Range (1, 5);
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
