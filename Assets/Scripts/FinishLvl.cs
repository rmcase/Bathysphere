using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishLvl : MonoBehaviour {

	public string levelToGoTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Exited level");

		other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		Invoke ("loadScene", .5f);
	}

	void loadScene() {
		SceneManager.LoadScene (levelToGoTo, LoadSceneMode.Single);
	}

}
