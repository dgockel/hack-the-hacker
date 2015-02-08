using UnityEngine;
using System.Collections;

public class FinalButtonController : MonoBehaviour 
{
	public GameObject berry;
	
	private BerryController berryController;
	
	public int id;
	
	private bool isPressed = false;
	// Use this for initialization
	void Start () 
	{
		berryController = berry.GetComponent<BerryController>();
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
			berryController.AddButton (id);
		}
		
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "Crate")
		{
			GetComponent<SpriteRenderer>().enabled = true;
			berryController.RemoveButton(id);
		}
	}
}
