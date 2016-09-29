using UnityEngine;
using System.Collections;

public class IcebergMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Rigidbody2D> ().position.x < -50) {
			Debug.Log ("Destroyed");
			Destroy (gameObject);
		}

	}
		
}
