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
	
	public float jumpForce = 1;
	private bool jumping = false;
	
	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Check if player is on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool("ground", grounded);
	
		float moveX = Input.GetAxis ("Horizontal");
		float speed = moveX * speedFactor;
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
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
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
