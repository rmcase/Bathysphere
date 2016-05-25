using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private int score;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		score = HUD.getScore ();
		GetComponent<Text> ().text = score.ToString();
	}
}
