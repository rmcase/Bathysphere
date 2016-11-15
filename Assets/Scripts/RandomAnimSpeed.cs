using UnityEngine;
using System.Collections;

public class RandomAnimSpeed : MonoBehaviour {

	public float min, max;
	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().speed = Random.Range (min, max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
