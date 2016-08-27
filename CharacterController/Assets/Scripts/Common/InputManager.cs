using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: Strictly a class library to handle input from users to control their current character.
	 *	    Refers heavily to the Movement class to perform its actions in terms of mobility.
	 */

	// TODO: Need to alter the move speed based on diagonal travel. The combination of forward and sideways movement multiplies to allow faster
	// TODO: movement. Classic cheating technique. Apparently nothing to change?
	public static void EnablePlayerControl(GameObject obj, Dictionary<string,float> properties) {
		/* 
		* Bread and butter of movement within the game, constant if statements allow for multi directional pathing.
		* By avoiding the use of a switch statement, we can eliminate the possibility of static mobility
		*/
		float movespeed;
		if (properties.TryGetValue(PropertyManager.CHARACTER_MOVESPEED,out movespeed)) {
			if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
				Movement.Move(obj,movespeed,Movement.MOVEMENT_FORWARD);
			if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
				Movement.Move(obj,movespeed,Movement.MOVEMENT_RIGHT);
			if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
				Movement.Move(obj,movespeed,Movement.MOVEMENT_LEFT);
			if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
				Movement.Move(obj,movespeed,Movement.MOVEMENT_BACKWARDS);
		}

		if (Input.GetKey("space")) {
			float jumpforce = 1.0f;
			float jumpstatus = 1.0f;
			if (
				properties.TryGetValue(PropertyManager.CHARACTER_JUMP_FORCE,out jumpforce) &&
				properties.TryGetValue(PropertyManager.CHARACTER_JUMP_STATUS,out jumpstatus)
			)
				Movement.Jump(obj,jumpforce,jumpstatus);
		}
	}
}
