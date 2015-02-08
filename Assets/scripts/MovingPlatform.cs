using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public int Frames = 60;
	public float Speed;
	private bool MovingRight = true;

	private int currentframe;
	private Vector2 InitialPosition;

	// Use this for initialization
	void Start () {
	
		currentframe = Frames;
		InitialPosition = rigidbody2D.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (currentframe < 0) {
			currentframe = Frames;
			MovingRight = !MovingRight;
		}

		Vector2 PlatformVelocity = rigidbody2D.velocity;
		PlatformVelocity.x = Speed;
		PlatformVelocity.y = 0f;

		if (MovingRight)
			rigidbody2D.velocity = PlatformVelocity;
		else
			rigidbody2D.velocity = -PlatformVelocity;

		currentframe--;

	}
}
