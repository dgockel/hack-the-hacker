using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speedFactor;
	
	private Animator animator;
	private bool facingRight = true;
	
	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	public float jumpForce;
	
	private bool _hasCoffee;
	public float coffeeFactor;
	
	public bool hasCoffee
	{
		get
		{
			return _hasCoffee;
		}
		set
		{
			_hasCoffee = value;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		hasCoffee = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Check if player is on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool("ground", grounded);
		
		// Check if player has coffee
		animator.SetBool ("coffee", hasCoffee);
	
		float moveX = Input.GetAxis ("Horizontal");
		float speed = moveX * speedFactor;
		
		// If we have coffee, increase speed.
		if(hasCoffee)
		{
			speed *= coffeeFactor;
		}
		
		rigidbody2D.velocity = new Vector2(speed, 0);
		animator.SetFloat("speed", Mathf.Abs (speed));
		
		if((speed > 0 && !facingRight)
			|| (speed < 0 && facingRight))
			Flip ();
	}
	
	void Update()
	{
		if(grounded && Input.GetKeyDown (KeyCode.Space))
		{
			animator.SetBool ("ground", false);
			float lJumpForce = jumpForce;
			if(hasCoffee)
			{
				lJumpForce *= coffeeFactor;
			}
			
			rigidbody2D.AddForce (new Vector2(0, lJumpForce), ForceMode2D.Force);
		}
		if(Input.GetKeyDown (KeyCode.R)
		   || !grounded && rigidbody2D.position.y < -6)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	  
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
