using UnityEngine;
using System.Collections;

public class pipePosition : MonoBehaviour {

	public Vector3 screenPosition;
	public Camera camera;
	// Use this for initialization
	void Start () {
		screenPosition = new Vector3(0,20,2);

		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =  camera.ScreenToWorldPoint(screenPosition);
	}
}
