using UnityEngine;
using System.Collections;

public class torpedoFixedPos : MonoBehaviour {

	public Vector3 pos1, pos2, pos3;
	public Transform torpedo;

	private Transform player;
	private bool needWave;

	// Use this for initialization
	void Start () {
		createWave ();

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		needWave = false;

		if (player.position.x > -9 && player.position.x < -8.95f) {
			needWave = true;
		}

		if (player.position.x > 5 && player.position.x < 5.05) {
			needWave = true;
		}

		if (needWave) {
			createWave ();
		}
	}

	public void createWave() {
		print ("wave incoming");
		Instantiate (torpedo, pos1, Quaternion.identity);
		Instantiate (torpedo, pos2, Quaternion.identity);
		Instantiate (torpedo, pos3, Quaternion.identity);

	}
}
