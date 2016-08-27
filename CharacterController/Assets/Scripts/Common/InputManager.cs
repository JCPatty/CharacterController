using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: Strictly a class library to handle input from users to control their current character.
	 *	    Refers heavily to the Movement class to perform its actions in terms of mobility.
	 */

	// TODO: Need to alter the move speed based on diagonal travel. The combination of forward and sideways movement multiplies to allow faster
	// TODO: movement. Classic cheating technique. Apparently nothing to change?
	public static void EnablePlayerControl(GameObject obj, float movespeed = 1.0f) {
		if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
			Movement.Move(obj,movespeed,Movement.MOVEMENT_FORWARD);
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
			Movement.Move(obj,movespeed,Movement.MOVEMENT_RIGHT);
		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
			Movement.Move(obj,movespeed,Movement.MOVEMENT_LEFT);
		if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
			Movement.Move(obj,movespeed,Movement.MOVEMENT_BACKWARDS);
	}
}
