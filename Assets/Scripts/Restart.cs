using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public Rigidbody2D player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnTriggerExit2D(Collider2D other) {
		Reset ();
	}

	void Reset() {
		
		HUD.score = 0;
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);

	}
}
