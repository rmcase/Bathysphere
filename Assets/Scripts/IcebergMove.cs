using UnityEngine;
using System.Collections;

public class IcebergMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Rigidbody2D> ().position.x < -160) {
			Debug.Log ("Destroyed");
			Destroy (gameObject);
		}
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0);

	}
		
}
