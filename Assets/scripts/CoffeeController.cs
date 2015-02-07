using UnityEngine;
using System.Collections;

public class CoffeeController : MonoBehaviour 
{
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			collider.gameObject.GetComponent<PlayerController>().hasCoffee = true;
			gameObject.SetActive(false);
		}
	}
}
