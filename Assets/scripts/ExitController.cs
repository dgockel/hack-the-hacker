using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	public string sceneToLoad;
	public bool stopMusic = false;
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
		if(stopMusic == true)
		{
			Destroy(GameObject.FindGameObjectWithTag ("MainMusic"));
		}
		Application.LoadLevel(sceneToLoad);
	}
}
