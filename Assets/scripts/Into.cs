using UnityEngine;
using System.Collections;

public class Into : MonoBehaviour {

	public int _state = 0;
	public bool _faceRight = false;
	public int _pacecount = 0;

	Animator _anim;
	GameObject test;

	// Use this for initialization
	void Start () {
	
		_anim = GetComponent<Animator>();
		test = GameObject.FindGameObjectWithTag ("Text");
		test.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		StateMachine();
	}

	void StateMachine()
	{
		Vector2 Destination = new Vector2();
		float move = 100.0f;
		int maxpace = 1;
		

		switch (_state) 
		{
		case 0:
			Destination.x = 4.23f;
			if(_faceRight) Flip(1);

			move = 2f;
			rigidbody2D.velocity = new Vector2(move, rigidbody2D.velocity.y);
			if (rigidbody2D.position.x >= Destination.x && _pacecount <=maxpace)
			{
				_state=1;
			}
			else if(_pacecount>maxpace)
			{
				_state = 2;
			}
			break;

		case 1:
			move = -2f;

			if(!_faceRight) Flip(-1);

			Destination.x = -0.75f;
			rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
			if(rigidbody2D.position.x <= Destination.x)
			{
				_state=0;
				_pacecount++;
			}
			break;

		case 2:
			_anim.SetBool("test", true);
			test.SetActive(true);
			rigidbody2D.velocity = new Vector2(0f,0f);
			//_state = 3;
			break;


     	}
	}

	void Flip(int scalevalue)
	{
		_faceRight = !_faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x = scalevalue;
		transform.localScale = theScale;
	}
}
