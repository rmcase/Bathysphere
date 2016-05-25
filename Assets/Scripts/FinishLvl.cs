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

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Exited level");

		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene (levelToGoTo, LoadSceneMode.Single);
		}
	}
}
