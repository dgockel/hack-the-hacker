using UnityEngine;
using System.Collections;

public class KittyController : MonoBehaviour 
{
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
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevel);
		}	
	}
}
