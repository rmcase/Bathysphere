using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private int score;
	public Text scoreTextView;
	public Text level;

	// Use this for initialization
	void Start () {
		level.text = HUD.getLevelAsNum().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		score = HUD.getScore ();
		scoreTextView.text = score.ToString();
	}
}
