using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float levelStart, levelEnd;

	private Transform bounds;
	private RectTransform boundsRect;
	private float width;
	private float camWidth;

	void Start() {
		bounds = GameObject.FindGameObjectWithTag ("Bounds").transform;
		boundsRect = (RectTransform) bounds;
		width = boundsRect.rect.width;

		camWidth = (Camera.main.orthographicSize * 2f) * (Camera.main.aspect);

		print ("bounds:" + bounds.position.x);

		Vector3 wPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 5));
		transform.position = wPos;
//		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);
	}
	// Update is called once per frame
	void Update () {

//		Vector3 wPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 5));
//		transform.position = wPos;
//		transform.position = new Vector3(Mathf.Clamp(transform.position.x, wPos.x + 10, wPos.x + 10), transform.position.y, transform.position.z);
//		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, levelStart, levelEnd), transform.position.y, transform.position.z);
	}
}
