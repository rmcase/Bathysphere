using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float levelStart, levelEnd;

	private bool switcher;

	void Start() {
		switcher = true;
	}
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);

//		if (player.gameObject != null) {
//			if (switcher) { 
//				transform.position = 
//				new Vector3 (player.position.x + offset.x, transform.position.y, -1); // Camera follows the player with specified offset position
//			}
//		}
			
	}
}
