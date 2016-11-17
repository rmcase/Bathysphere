using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject main, restart, highscore, xpress, score, hsButton;

	// Use this for initialization
	void Start () {
		highscore.SetActive (false);
		xpress.SetActive (false);
		score.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	}

	public void MainMenu() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	public void Restart() {
		SceneManager.LoadScene ("Lvl 1", LoadSceneMode.Single);
	}

	public void HighScore() {
		hsButton.SetActive (false);
		main.SetActive (false);
		restart.SetActive (false);
		highscore.SetActive (true);
		score.SetActive (true);
		xpress.SetActive (true);
	}

	public void xPress() {
		hsButton.SetActive (true);
		score.SetActive (false);
		highscore.SetActive (false);
		main.SetActive (true);
		restart.SetActive (true);
		xpress.SetActive (false);
	}
}
