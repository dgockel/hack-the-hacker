using UnityEngine;
using System.Collections;

public class BerryController : MonoBehaviour 
{
	private Animator animator;
	
	private enum BerryState { Idle, Walking, Throwing, Wahhh, Throw };
	private BerryState mState = BerryState.Idle;
	
	public int ThrowingCount;
	public int ThrowCount;
	
	private int idleCount = 50;
	private int throwingCount;
	private int throwCount;
	
	public float walkSpeed;
	
	public GameObject kitty;
	
	private Random rng;
	
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
	
	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		throwingCount = ThrowingCount;
		throwCount = ThrowCount;
		rng = new Random();
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
			cat.rigidbody2D.angularVelocity = 360;
			
		}
	}
	
	private void Wahhh()
	{
		
	}
	
	private void UpdateState()
	{
		animator.SetInteger("State", (int)mState);
	}
	
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
