using UnityEngine;
using System.Collections;

public class torpedoGeneration : MonoBehaviour {

	public int maxTorpedos;
	public Transform torpedo;

	private const float Y_MAX = 1.90f;
	private const float Y_MIN = -3.0f;
	// Use this for initialization
	void Start () {
		generateWave (Random.Range(4, maxTorpedos));
//		for (int i = 0; i < numOfWaves; i++) {
//			StartCoroutine (waveTimer());
//		}
			
	}

	// Update is called once per frame
	void Update () {
	}


	void generateWave (int num)
	{
		print ("new wave");

		for (int i = 0; i < num; i++) {
			float y;
			y = Random.Range (Y_MIN, Y_MAX);
			Vector3 position = new Vector3 (54, y, 0);
		
			Instantiate (torpedo, position, Quaternion.identity);

		}
	}

	Vector3 newPosition(Vector3 pos) {
		if (Physics2D.OverlapCircle (pos, 1.2f) == null) {
			return pos;
		} else {
			print ("finding new position");
			return newPosition (new Vector3 (54, Random.Range (Y_MIN, Y_MAX), 0));
		}
	}

}
