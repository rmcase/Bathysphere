using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class HUD : object {

	public static int score = 0;

	public static void addScore(int pointsEarned) {
		score += pointsEarned;
	}

	public static int getScore() {
		return score;
	}

	public static string getLevel() {
		return SceneManager.GetActiveScene ().name;
	}
}
