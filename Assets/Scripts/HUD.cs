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

	public static int getLevelAsNum() {
		int retval = 0;
		string level = SceneManager.GetActiveScene ().name;

		if (level.Contains ("1"))
			retval = 1;
		else if (level.Contains ("2"))
			retval = 2;
		else if (level.Contains ("3"))
			retval = 3;

		return retval;
	}

}
