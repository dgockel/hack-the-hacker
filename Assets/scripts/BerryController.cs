using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BerryController : MonoBehaviour 
{
	private Animator animator;
	
	private enum BerryState { Idle, Walking, Throwing, Wahhh, Throw, End };
	private BerryState mState = BerryState.Idle;
	
	public int ThrowingCount;
	public int ThrowCount;
	public int EndDelay;
	
	private int idleCount = 50;
	private int throwingCount;
	private int throwCount;
	
	private AudioSource audio;
	
	public float walkSpeed;
	
	public GameObject kitty;
	
	public GameObject camera;
	
	public GameObject spring;
	public SpringController springController;
	
	private Random rng;
	
	private List<int> buttons;
	
	private bool gameEnd = false;
	public bool GameEnd
	{
		get
		{
			return gameEnd;
		}
		set
		{
			gameEnd = value;
		}
	}
	
	public void AddButton(int id)
	{
		if(!buttons.Contains (id))
		{
			buttons.Add (id);
		}
		if(buttons.Count == 3)
		{
			mState = BerryState.Wahhh;
			UpdateState();
			return;
		}
		Debug.Log (buttons.Count);
	}
	
	public void RemoveButton(int id)
	{
		if(buttons.Contains(id))
		{
			buttons.Remove(id);
		}
		Debug.Log (buttons.Count);
	}
	
	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		throwingCount = ThrowingCount;
		throwCount = ThrowCount;
		rng = new Random();
		buttons = new List<int>();
		audio = gameObject.GetComponent<AudioSource>();
		springController = spring.gameObject.GetComponent<SpringController>();
		Flip ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		switch(mState)
		{
			case BerryState.Idle:
				Idle();
				break;
			case BerryState.Walking:
				Walking ();
				break;
			case BerryState.Throwing:
				Throwing ();
				break;
			case BerryState.Wahhh:
				Wahhh ();
				break;
			case BerryState.Throw:
				Throw ();
				break;
			case BerryState.End:
				End();
				break;
		}
	}
	
	private void Idle()
	{
		if(--idleCount <= 0)
		{
			mState = BerryState.Walking;
			UpdateState ();
		}
	}
	
	private void Walking()
	{
		rigidbody2D.velocity = new Vector2(-walkSpeed, 0);
		if(rigidbody2D.position.x < 9.6)
		{
			mState = BerryState.Throwing;
			UpdateState ();
		}
	}
	
	private void Throwing()
	{
		if(throwingCount-- <= 0)
		{
			throwingCount = ThrowingCount;
			mState = BerryState.Throw;
			UpdateState ();
		}
	}
	
	private void Throw()
	{
		if(throwCount-- <= 0)
		{
			throwCount = ThrowCount;
			mState = BerryState.Throwing;
			UpdateState();
			
			GameObject cat = (GameObject)Instantiate (kitty);
			cat.SetActive(true);
			cat.rigidbody2D.velocity = new Vector2(Random.Range (-25, 0), Random.Range (-1, 3));
		}
	}
	
	private void Wahhh()
	{
		springController.ExtendSpring();
		
		AudioSource.PlayClipAtPoint(audio.clip, new Vector3(0, 0, 0));
		gameObject.rigidbody2D.fixedAngle = false;
		gameObject.rigidbody2D.velocity = new Vector2(-22, 0);
		mState = BerryState.End;
	}
	
	private void UpdateState()
	{
		animator.SetInteger("State", (int)mState);
	}
	
	private void End()
	{
		if(EndDelay-- <= 0)
		{
			Destroy(GameObject.FindGameObjectWithTag ("FinalMusic"));
			Application.LoadLevel("Credits");
		}
	}	
	
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
