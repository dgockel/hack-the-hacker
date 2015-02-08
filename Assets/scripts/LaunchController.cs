using UnityEngine;
using System.Collections;

public class LaunchController : MonoBehaviour 
{
	public float launchVelocity;
	private bool hasLaunched = false;
	
	public void Launch()
	{
		if(!hasLaunched)
		{
			gameObject.rigidbody2D.velocity = new Vector2(-launchVelocity, 0);
			hasLaunched = true;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
