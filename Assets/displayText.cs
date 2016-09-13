using UnityEngine;
using System.Collections;

public class displayText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),"BOOST RECHARGED");
	}
}
