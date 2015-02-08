using UnityEngine;
using System.Collections;
using System.Threading;

public class Into : MonoBehaviour {

	public int _state = 0;
	public bool _faceRight = false;
	public int _pacecount = 0;

	private float timeLeft = 1f;

	private Animator _anim;
	private GameObject _object1;
	private GameObject _object2;
	private GameObject _object3;
	private GameObject _object4;

	// Use this for initialization
	void Start () {

		_anim = GetComponent<Animator> ();
		_object1 = GameObject.FindGameObjectWithTag ("Text");
		_object1.SetActive (false);

		_object2 = GameObject.FindGameObjectWithTag ("LightBulb");
		_object2.SetActive (false);

		_object3 = GameObject.FindGameObjectWithTag ("ComputerText");
		_object3.SetActive (false);

		_object4 = GameObject.FindGameObjectWithTag ("QuestionMark");
		_object4.SetActive (false);


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		StateMachine();
	}

	void StateMachine()
	{
		Vector2 Destination = new Vector2();
		float move = 2.0f;
		int maxpace = 1;
		float waittime = 1f;
		

		switch (_state) 
		{
		// walk tot he chalk board.
		case 0:
			Destination.x = 4.23f;
			if(_faceRight) Flip(1);
			Debug.Log(timeLeft.ToString ());
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

		// pace in front of the chalk board.
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

		// turn the light bulb on
		case 2:
			_anim.SetBool("test", true);
			_object1.SetActive(true);
			_object2.SetActive(true);
			rigidbody2D.velocity = new Vector2(0f,0f);

			if(countdown())
			{
				timeLeft = waittime;
				Debug.Log("it worked");
			 	_state = 3;
			}
			break;

		// Computer gets hacked
		case 3:
			_object3.SetActive(true);
			if(countdown()) 
			{
				timeLeft = waittime;
				_state = 4;
			}
			break;

		//question mark
		case 4:
			_object2.SetActive(false);
			_object4.SetActive(true);
			if(countdown())
			{
				timeLeft = waittime;
				_state = 5;
			}
			break;

		//Walk over to the computer
		case 5:
			Destination.x = 6.09f;
			move = 2f;
			_anim.SetBool("test",false);
			rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
			if(rigidbody2D.position.x >= Destination.x)
			{
				_state=6;
			}
			break;

		//stop in front of computer
		case 6:
			rigidbody2D.velocity = new Vector2(0f,0f);
			_anim.SetBool("test",true);
			if(countdown())
			{
				_state = 7;
				timeLeft = waittime;
			}
			break;

		//walk to the door to start first level
		case 7:
			move = -2f;
			Destination.x = -3.75f;
			_anim.SetBool("test", false);
			if(!_faceRight) Flip(-1);
			rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);

			if(rigidbody2D.position.x <= Destination.x)
			{
				Debug.Log ("test");
				Application.LoadLevel("Level 1");
			}
			break;
     	}
	}

	bool countdown()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft < 0) return true;
		else return false;
	}
	
	void Flip(int scalevalue)
	{
		_faceRight = !_faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x = scalevalue;
		transform.localScale = theScale;
	}
}
