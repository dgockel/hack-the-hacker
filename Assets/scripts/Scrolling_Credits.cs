using UnityEngine;
using System.Collections;

public class Scrolling_Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 ScrollVelocity = rigidbody2D.velocity;
		ScrollVelocity.x = 0.0f;
		ScrollVelocity.y = 2f;

		rigidbody2D.velocity = ScrollVelocity;

		if (rigidbody2D.position.y > 10f) {
			Application.LoadLevel("MainMenu");
		}
	}


}
