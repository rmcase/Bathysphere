using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToMenu() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	public void resetLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
	}
}
