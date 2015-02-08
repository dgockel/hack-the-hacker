using UnityEngine;
using System.Collections;

public class CoffeeController : MonoBehaviour 
{
	public GameObject player;
	private AudioSource audio;

	// Use this for initialization
	void Start () 
	{
		audio = gameObject.GetComponent<AudioSource>();
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
			AudioSource.PlayClipAtPoint(audio.clip, new Vector3(0, 0, 0));
			gameObject.SetActive (false);
		}
	}
}
