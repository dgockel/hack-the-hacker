using UnityEngine;
using System.Collections;

public class VerticalMovingPlatform : MonoBehaviour 
{
	public float yMax;
	public float yMin;
	public int periodFrames;
	
	private bool DirectionUp = false;
	private float MovingDistance;
	
	// Use this for initialization
	void Start () 
	{
		MovingDistance = yMax - yMin;
		Debug.Log ("Moving distance: " + MovingDistance);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 position = gameObject.rigidbody2D.position;
		if((DirectionUp && position.y >= yMax)
		   || (!DirectionUp && position.y <= yMin))
		{
			DirectionUp = !DirectionUp;
		}
		
		int directionMultiplier = DirectionUp ? 1 : -1;
		gameObject.rigidbody2D.velocity = new Vector2(0, MovingDistance / periodFrames * directionMultiplier);
	}
	
	void FixedUpdate()
	{
		
	}
}
