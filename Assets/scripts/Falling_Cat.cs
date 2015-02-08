using UnityEngine;
using System.Collections;

public class Falling_Cat : MonoBehaviour {

	public float xboundary;

	// Use this for initialization
	void Start () {
	
		GetComponent<SpriteRenderer>().enabled = false;
		rigidbody2D.gravityScale = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (GameObject.FindGameObjectWithTag ("Player").rigidbody2D.position.x.ToString ());
		if (GameObject.FindGameObjectWithTag ("Player").rigidbody2D.position.x > xboundary) {
			Debug.Log ("test");
			GetComponent<SpriteRenderer>().enabled = true;
			rigidbody2D.gravityScale = 5f;
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel);
		}	
	}

}
