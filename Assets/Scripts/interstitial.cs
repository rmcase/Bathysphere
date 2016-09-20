using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class interstitial : MonoBehaviour {

	public string nextLvl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchSupported) {
			if (Input.touchCount == 1) {
				loadNext (nextLvl);
			}
		} else {
			if (Input.GetMouseButton (0)) {
				//Touch anywhere
				loadNext(nextLvl);
			}
		}
	}

	void loadNext(string nxtLvl) {
		SceneManager.LoadScene (nxtLvl, LoadSceneMode.Single);
	}
}
