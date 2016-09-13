using UnityEngine;
using System.Collections;

public class chargeGeneration : MonoBehaviour {

	public float minX, maxX, numOfCharges;
	public Transform depthCharge;

	// Use this for initialization
	void Start () {
		for(int i=0; i<numOfCharges; i++) {
			Instantiate (depthCharge, new Vector2 (Random.Range (minX, maxX), 4.2f), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
