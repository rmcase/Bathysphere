using UnityEngine;
using System.Collections;

public class Awake : MonoBehaviour {

	public Rigidbody2D player;
	public Vector2 force;
	public int distance;

	private Rigidbody2D barrel;
	// Use this for initialization
	void Start () {
		//barrel = GetComponent<Rigidbody2D> ();
		barrel = GetComponentInChildren<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(player.position.x - barrel.position.x) < distance) {
			//Debug.Log ("Woken");
			barrel.WakeUp();
			barrel.AddForce (force);
		}

		if (barrel.position.y < 0) {
			barrel.MovePosition (new Vector2 (barrel.position.x, -1));
			//barrel.GetComponent<Animator> ().Play ("Explosion");
			GetComponentInChildren<Animator> ().Play ("Explosion");
			Debug.Log ("crossfaded");
		}

	}

}
