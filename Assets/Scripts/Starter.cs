using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour {

	public GameObject credits, help, highscore, xpress, score;

	// Use this for initialization
	void Start () {
		credits.SetActive (false);
		help.SetActive (false);
		highscore.SetActive (false);
		xpress.SetActive (false);
		score.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public void Help() {
		help.SetActive (true);
		xpress.SetActive (true);
	}

	public void Credits() {
		credits.SetActive (true);
		xpress.SetActive (true);
	}

	public void HighScore() {
		highscore.SetActive (true);
		score.SetActive (true);
		xpress.SetActive (true);
	}

	public void xPress() {
		score.SetActive (false);
		highscore.SetActive (false);
		credits.SetActive (false);
		help.SetActive (false);
		xpress.SetActive (false);
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
