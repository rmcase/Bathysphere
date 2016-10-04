using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class setHighscore : MonoBehaviour {

	public UnityEngine.UI.Text theText;

	// Use this for initialization
	void Start () {
		theText.text = PlayerPrefs.GetInt ("HighScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
