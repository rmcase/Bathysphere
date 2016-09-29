using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float levelStart, levelEnd;

	private Transform bounds;

	void Start() {
		bounds = GameObject.FindGameObjectWithTag ("Bounds").transform;

		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);
	}
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);
//		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, bounds.position.x, levelEnd), transform.position.y, transform.position.z);
			
		if (GetComponent<Animator> ().GetAnimatorTransitionInfo(0).normalizedTime > 1) {
			GameObject.FindGameObjectWithTag ("ChargeText").SetActive (false);
		}
	}
}
