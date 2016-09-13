using UnityEngine;
using System.Collections;

public class objectGenerator : MonoBehaviour {

	public Transform mine;
	public int numOfMines;

	private Vector3 position;

	// Use this for initialization
	void Start () {
//		for (int i = 0; i < numOfMines; i++) {
//			float x, y;
//			x = Random.Range (-20, 27);
//			y = Random.Range (-4.0f, -8.0f);
//
//			position = new Vector3 (x, y, 0);
//		}

		float x, y, xX;

		for (int i = 0; i < numOfMines; i++) {
			x = Random.Range (-20, 27);
			xX = -20;
			y = Random.Range (-4.5f, 0f);

			position = new Vector3 (x, y, 0);

			Instantiate(mine, new Vector3(xX + 5*i, y, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		createMine = false;
//
//		if (Physics.CheckSphere (position, 9.25f)) {
//			position = new Vector3 (Random.Range (-20, 27), Random.Range (-4.0f, -8.0f), 0);
//
//		} else {
//			createMine = true;
//		}
//
//		if (createMine == true && count <= numOfMines) {
//			Instantiate (mine, position, Quaternion.identity);
//			count++;
//
//		}
	}

	Vector3 checkPosition(Vector3 pos) {

		return new Vector3 ();
	}
}
