using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float levelStart, levelEnd;

	public GameObject pipeF, pipeB;

	private Transform bounds;
	private RectTransform boundsRect;

	void Start() {
		bounds = GameObject.FindGameObjectWithTag ("Bounds").transform;
		boundsRect = (RectTransform) bounds;

		Vector3 pos = new Vector3 (100, 215, 2);

		print ("bounds:" + bounds.position.x);

		pipeB.transform.position = GetComponent<Camera> ().ScreenToWorldPoint (pos);
//		pipeF.transform.position = GetComponent<Camera> ().ScreenToWorldPoint (pos);

//		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);
	}
		
	void Update () {
		
//		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);
	}
}
