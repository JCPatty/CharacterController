using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	// Set public variables
	public Camera playerCamera;
	public bool invertedY;

	// Set player controller properties :: Keep it fixed for now
	private float _movespeed = 2.5f;
	private float _gravity = 9.8f;
	private float _jumpforce = 2.5f;
	private float _lookspeed = 3.5f;

	// Gameplay Character properties
	private int _maxhealth = 100;
	private int _maxenergy = 100;

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

		// TODO: Need to alter the move speed based on diagonal travel. The combination of forward and sideways movement multiplies to allow faster
		// TODO: movement. Classic cheating technique. Apparently nothing to change?
		if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * Time.deltaTime * _movespeed);
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
			transform.Translate(Vector3.right * Time.deltaTime * _movespeed);
		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(Vector3.left * Time.deltaTime * _movespeed);
		if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
			transform.Translate(Vector3.back * Time.deltaTime * _movespeed);


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
