using UnityEngine;
using System.Collections;

public class Falling_Cat : MonoBehaviour {

	public float xboundary;
	private AudioSource audio;
	
	private bool soundPlayed = false;

	// Use this for initialization
	void Start () {
	
		GetComponent<SpriteRenderer>().enabled = false;
		rigidbody2D.gravityScale = 0f;
		audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (GameObject.FindGameObjectWithTag ("Player").rigidbody2D.position.x.ToString ());
		if (GameObject.FindGameObjectWithTag ("Player").rigidbody2D.position.x > xboundary) {
			Debug.Log ("test");
			GetComponent<SpriteRenderer>().enabled = true;
			rigidbody2D.gravityScale = 5f;
			if(!soundPlayed)
			{
				AudioSource.PlayClipAtPoint(audio.clip, new Vector3(0, 0, 0));
				soundPlayed = true;
			}
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
