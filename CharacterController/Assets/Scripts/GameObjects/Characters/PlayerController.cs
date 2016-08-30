using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

	// Set public variables
	public Camera playerFPCamera;	// First Person Camera
	public Camera playerTPCamera;   // Third Person Camera
	public GameObject player;

	// Camera related stuff
	public bool invertedY;

	// Gameplay Character properties
	private int _maxhealth = 100;
	private int _maxenergy = 100;

	// Original Transform and Quaternion Origin
	private Quaternion _originalRotation;
	private Vector3 _startingPos;

	// Player position. Used to calculate jumping velocity without use of rigidbody physics
	private Vector3 lastKnownPos;
	private float _jumpstatus = 0.0f;

	/* Variables below this declaration get passed into different functions, more as a global information parser */
	private Dictionary<string,float> _parseValues = new Dictionary<string,float>();

	// Set player controller properties :: Keep it fixed for now
	private float _movespeed = 2.5f;
	private float _jumpforce = 5.0f;
	private float _gravity = 9.8f;
	private float _lookspeed = 3.5f;

	/* Passed variables ends here */

	// Third person controller variables
	private Vector3 offset;

	// Use this for initialization
	void Start()
	{
		offset = new Vector3(transform.position.x,transform.position.y,transform.position.z + 3.0f); 

		_originalRotation = transform.rotation;
		_startingPos = transform.position;
		lastKnownPos = transform.position;

		// Sort all potential float values for other classes
		_parseValues.Add(PropertyManager.CHARACTER_JUMP_FORCE,_jumpforce);
		_parseValues.Add(PropertyManager.CHARACTER_MOVESPEED,_movespeed);
		_parseValues.Add(PropertyManager.CHARACTER_JUMP_STATUS,_jumpstatus);
	}

	// Update is called once per frame
	void Update()
	{
		Camera playerCamera = PlayerController.GetActiveCamera(gameObject);
		if (Input.GetKeyDown(KeyCode.LeftAlt)) {
			if (playerFPCamera.enabled) {
				playerFPCamera.enabled = false;
				playerTPCamera.enabled = true;
			} else {
				playerFPCamera.enabled = true;
				playerTPCamera.enabled = false;
			}
		}

		this.SetLastKnownPos(transform.position);

		/*
		 Assisted thread http://answers.unity3d.com/questions/363943/mouse-lookrotate.html
		 Essentially sticks to the use of mouse float values and geometric countering for inverted operation.
		 */

		if (playerCamera.CompareTag(TagManager.CAMERA_FIRST_PERSON)) {
			// First Person Handler, just like any shooter would be like
			InputManager.EnablePlayerFPControl(gameObject,_parseValues);

			float mouseInputX = Input.GetAxis("Mouse X") * _lookspeed;
			Vector3 lookhereX = new Vector3(0, mouseInputX, 0);
			transform.Rotate(lookhereX);


			float mouseInputY = (invertedY ? -Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y")) * _lookspeed;
			Vector3 lookhereY = new Vector3(mouseInputY, 0, 0);
			playerCamera.transform.Rotate(lookhereY);
		} else if (Input.GetMouseButton(1)) {
			// Third Person Handler as well, this effects the characters orientation and direction of travel
		} else {
			// Third Person Handler, runs like any mmo, left click hold will allow camera angle change only
			if (Input.GetMouseButton(0)) {
				offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _lookspeed,Vector3.up) * offset;
				offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * _lookspeed,Vector3.right) * offset;
			}
			playerCamera.transform.position = transform.position + offset;
			playerCamera.transform.LookAt(transform.position);
			InputManager.EnablePlayerTPControl(gameObject,_parseValues);
		}
	}

	// Need it to be static, other functions have to rely on this to determine from the game object
	public static Camera GetActiveCamera(GameObject obj) {
		if (obj.GetComponent<PlayerController>().playerFPCamera.enabled)
			return obj.GetComponent<PlayerController>().playerFPCamera;
		else
			return obj.GetComponent<PlayerController>().playerTPCamera;
	}

	public static bool CameraFirstPerson(float cameravalue) {
		if (cameravalue == 0.0f)
			return false;
		else
			return true;
	}

	// This can only be used with the definition of a player gameobject, no point making it static
	public Vector3 GetLastKnownPos() {
		return lastKnownPos;
	}

	public void SetLastKnownPos(Vector3 new_pos) {
		lastKnownPos = new_pos;
	}

	public void SetJumpStatus(bool status) {
		if (status)
			_jumpstatus = 1.0f;
		else
			_jumpstatus = 0.0f;
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
