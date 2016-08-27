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

	// JamesChange 270816: Heavily dependant on the fact of having a jumping state
	public static void Jump(GameObject obj, float jumpforce) {
		obj.GetComponent<Rigidbody>().velocity = new Vector3(0,5,0);
		/*if (status > 0) {
			obj.GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpforce,0),ForceMode.Impulse);
			obj.SendMessage("UpdateJumpStatus",0.0f);
		}*/
	}
}
