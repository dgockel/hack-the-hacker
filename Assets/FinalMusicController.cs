using UnityEngine;
using System.Collections;

public class FinalMusicController : MonoBehaviour 
{
	private static FinalMusicController instance = null;
	public static FinalMusicController Instance
	{
		get { return instance; }
	}
	
	void Awake() {
		
	}
	
	// Use this for initialization
	void Start () 
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} 
		else 
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
