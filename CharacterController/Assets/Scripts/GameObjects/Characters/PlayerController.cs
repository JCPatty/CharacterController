using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

	// Set public variables
	public Camera playerCamera;
	public GameObject player;
	public bool invertedY;

	// Set player controller properties :: Keep it fixed for now
	private float _movespeed = 2.5f;
	private float _gravity = 9.8f;
	private float _jumpforce = 2.5f;
	private float _lookspeed = 3.5f;

	// Gameplay Character properties
	private int _maxhealth = 100;
	private int _maxenergy = 100;
	private Dictionary<string,float> _parseValues = new Dictionary<string,float>();

	// Original Transform and Quaternion Origin
	private Quaternion _originalRotation;
	private Vector3 _startingPos;

	// Use this for initialization
	void Start()
	{
		_originalRotation = transform.rotation;
		_startingPos = transform.position;

		// Sort all potential float values for other classes
		_parseValues.Add(PropertyManager.CHARACTER_JUMP_FORCE,_jumpforce);
		_parseValues.Add(PropertyManager.CHARACTER_MOVESPEED,_movespeed);
	}

	// Update is called once per frame
	void Update()
	{
		InputManager.EnablePlayerControl(gameObject,_parseValues);

		/*
		 Assisted thread http://answers.unity3d.com/questions/363943/mouse-lookrotate.html
		 Essentially sticks to the use of mouse float values and geometric countering for inverted operation.
		 */
		float mouseInputX = Input.GetAxis("Mouse X") * _lookspeed;
		float mouseInputY = (invertedY ? -Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y")) * _lookspeed;
		Vector3 lookhereX = new Vector3(0, mouseInputX, 0);
		Vector3 lookhereY = new Vector3(mouseInputY, 0, 0);
		transform.Rotate(lookhereX);
		playerCamera.transform.Rotate(lookhereY);

	}

	// JamesChange 260816: This function needs to be moved to the Techniques class as it will be the prime controller source
	//			to detect input for abilities to be used.
	public string getInput()
	{
		string return_string = "";
		foreach (char c in Input.inputString)
		{
			print(c);
		}

		return return_string;
	}

	/* 
	 * FUN FACT! Didn't know this, but difference between OnCollisionEnter and OnTriggerEnter, triggers are used by the
	 * mesh colider, while the collision is detected through non kinomatic rigidbodies. Interesting...
	 */

	// JamesChange 260816: Need to create a global function to determine the information of the item colliding with.
	//		       What follows will be the behavioural handler based on information retrieved of the object that it has collided with.
	void OnCollisionEnter(Collision col) {
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == TagManager.ENVIRONMENT_LIMITER_BORDER)
			col.SendMessage("RespawnPlayer",player);
	}
}
