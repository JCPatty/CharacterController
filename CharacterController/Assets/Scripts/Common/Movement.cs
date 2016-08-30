using UnityEngine;
using System.Collections;

public class Movement {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: Strictly a class library, for the purpose of storing movement related functions.
	 *	    A list of voided actions to perform only once without the need to retain any data.
	 */

	// Basic movement constants
	public const string MOVEMENT_FORWARD = "forward";
	public const string MOVEMENT_RIGHT = "right";
	public const string MOVEMENT_LEFT = "left";
	public const string MOVEMENT_BACKWARDS = "backwards";
	public const string MOVEMENT_TURN_LEFT = "turnleft";
	public const string MOVEMENT_TURN_RIGHT = "turnright";

	// Intermediate action constants
	public const string ACTION_JUMP = "jump";
	public const string ACTION_ROLL = "roll";
	public const string ACTION_DIVE = "dive";
	public const string ACTION_HANG = "hang";
	
	public static void Move(GameObject obj, float movespeed = 1.0f,string orientation = "") {

		switch (orientation) {
			case MOVEMENT_FORWARD:
				obj.transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
			break;
			case MOVEMENT_RIGHT:
				obj.transform.Translate(Vector3.right * Time.deltaTime * movespeed);
			break;
			case MOVEMENT_LEFT:
				obj.transform.Translate(Vector3.left * Time.deltaTime * movespeed);
			break;
			case MOVEMENT_BACKWARDS:
				obj.transform.Translate(Vector3.back * Time.deltaTime * movespeed);
			break;
			default:
				Debug.Log("No direction has been provided. Just gonna chill here it seems until a developer does something about it.");
			break;
		}
	}

	public static void Turn(GameObject obj, float turnspeed = 1.0f, string direction = "") {
		switch (direction) {
			case MOVEMENT_TURN_LEFT:
				obj.transform.Rotate(new Vector3(0.0f,-turnspeed,0.0f));
			break;
			case MOVEMENT_TURN_RIGHT:
				obj.transform.Rotate(new Vector3(0.0f,turnspeed,0.0f));
			break;
			default:
				Debug.Log("No direction of turning has been provided. Stare straight friend... No one can hurt you now");
			break;
		}
	}

	// JamesChange 270816: Heavily dependant on the fact of having a jumping state
	public static void Jump(GameObject obj, float jumpforce) {
		// Determine direction of travel to apply force?
		Vector3 lastKnownPos = obj.GetComponent<PlayerController>().GetLastKnownPos();

		float direction_x = obj.transform.position.x - lastKnownPos.x;
		float direction_z = obj.transform.position.z - lastKnownPos.z;

		// Determine velocity of jumping object. At this point, the movement cannot be cancelled, the velocity has been retrieved.
		obj.GetComponent<Rigidbody>().velocity = new Vector3(0,jumpforce,0);
	}
}
