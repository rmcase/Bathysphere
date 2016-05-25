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

	public void BeginLevel() {
		SceneManager.LoadScene ("Lvl 2", LoadSceneMode.Single);
	}
}
