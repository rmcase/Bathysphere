using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform player;
	public Vector2 offset;
	public bool switcher;

	// Update is called once per frame
	void Update () {

		if (player.gameObject != null) {
			if (switcher) {
				transform.position = 
				new Vector3 (player.position.x + offset.x, transform.position.y, -1); // Camera follows the player with specified offset position
			}
		}

		if (transform.position.x > 10 && HUD.getLevel() == "Lvl 1")
			switcher = false;
	}
}
