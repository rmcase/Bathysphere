using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VolcanoCollision : MonoBehaviour {

	public CircleCollider2D player;
	public Vector2 volcanoVelocity;
	public Sprite sp0, sp1, sp2, sp3, sp4, sp5;

	private SpriteRenderer sp;
	private ArrayList list;

	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((sp.sprite == sp || sp.sprite == sp1 || sp.sprite == sp2 || sp.sprite == sp3 ||
			sp.sprite == sp4 || sp.sprite == sp5) && sp.GetComponent<BoxCollider2D>().IsTouching(player)) 
		{
			Debug.Log ("Volcano Hit");

			player.GetComponent<Rigidbody2D>().velocity = volcanoVelocity;

			player.GetComponent<CircleCollider2D> ().enabled = false;

			player.GetComponent<Animator> ().Play ("Implosion");

			Invoke ("Reset", 1.75f);
		}
	}
		

	void Reset() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}
