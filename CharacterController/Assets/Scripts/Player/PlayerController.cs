using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	// Set public variables
	public Camera _playerCamera;
	public GameObject _player;
	public bool _invertedY;

	// Set player properties :: Keep it fixed for now
	private float _movespeed = 2.5f;
	private float _gravity = 9.8f;
	private float _lookspeed = 3.5f;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

		/* 
		 * Bread and butter of movement within the game, constant if statements allow for multi directional pathing.
		 * By avoiding the use of a switch statement, we can eliminate the possibility of static mobility
		 */

		if (Input.GetKey("w"))
			transform.Translate(Vector3.forward * Time.deltaTime);

		/*
		 Assisted thread http://answers.unity3d.com/questions/363943/mouse-lookrotate.html
		 Essentially sticks to the use of mouse float values and geometric countering for inverted operation.
		 */
		float mouseInputX = Input.GetAxis("Mouse X") * _lookspeed;
		float mouseInputY = (_invertedY ? -Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y")) * _lookspeed;
		Vector3 lookhereX = new Vector3(0, mouseInputX, 0);
		Vector3 lookhereY = new Vector3(mouseInputY, 0, 0);
		transform.Rotate(lookhereX);
		_playerCamera.transform.Rotate(lookhereY);

		// Testing the input detection
		this.getInput();
	}

	// Seriously, fuck scoping. 360 no scope this shit
	public string getInput()
	{
		string return_string = "";
		foreach (char c in Input.inputString)
		{
			print(c);
		}

		return return_string;
	}
}
