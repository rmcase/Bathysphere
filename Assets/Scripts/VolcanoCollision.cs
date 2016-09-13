using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VolcanoCollision : MonoBehaviour {

	public CircleCollider2D player;
	public Vector2 volcanoVelocity;

	private ArrayList list;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			Debug.Log ("Volcano Hit");

			player.GetComponent<Rigidbody2D>().velocity = volcanoVelocity;

			player.GetComponent<CircleCollider2D> ().enabled = false;

			player.GetComponent<Animator> ().Play ("Implosion");

			Invoke ("Reset", 1.75f);
	}
		

	void Reset() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}
