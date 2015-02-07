using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
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
