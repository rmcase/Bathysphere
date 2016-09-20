using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D (Collision2D other) {
		Invoke ("Reset", 2.2f);
	}

	void Reset() {
		
		HUD.score = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name, LoadSceneMode.Single);

	}
}
