using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour {

	public bool me;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void HighScore() {
		SceneManager.LoadScene ("HighScore", LoadSceneMode.Single);
	}

	public void BeginLevel() {
		SceneManager.LoadScene ("Lvl 1", LoadSceneMode.Single);
	}

	public void Level2() {
		SceneManager.LoadScene ("Lvl 2", LoadSceneMode.Single);
	}

	public void Level3() {
		SceneManager.LoadScene ("Lvl 3", LoadSceneMode.Single);
	}
}
