using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour 
{
	private Animator animator;
	
	public void ExtendSpring()
	{
		animator.SetBool ("activated", true);
	}
	// Use this for initialization
	void Start () 
	{
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
