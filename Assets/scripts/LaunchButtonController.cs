using UnityEngine;
using System.Collections;

public class LaunchButtonController : MonoBehaviour 
{
	public GameObject spring;
	public GameObject launchCrate;
	
	private SpringController springController;
	private LaunchController launchController;
	
	// Use this for initialization
	void Start () 
	{
		springController = spring.GetComponent<SpringController>();
		launchController = launchCrate.GetComponent<LaunchController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{	
		if (other.gameObject.tag == "Player" || other.tag == "Crate")
		{
			GetComponent<SpriteRenderer>().enabled = false;
			springController.ExtendSpring();
			launchController.Launch ();
		}
		
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "Crate")
		{
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
