﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: Strictly a class library to handle input from users to control their current character.
	 *	    Refers heavily to the Movement class to perform its actions in terms of mobility.
	 */

	// TODO: Need to alter the move speed based on diagonal travel. The combination of forward and sideways movement multiplies to allow faster
	// TODO: Also need to disable movement while in jumping animation, either I will get back to this, or maybe someday I'll be able to get someone else to do it.
	// TODO: movement. Classic cheating technique. Apparently nothing to change?
	public static void EnablePlayerFPControl(GameObject obj, Dictionary<string,float> properties) {
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
			float distance = 0.0f;

			RaycastHit hit;
			if (Physics.Raycast(obj.transform.position,-Vector3.up,out hit))
				distance = hit.distance;

			if (
				properties.TryGetValue(PropertyManager.CHARACTER_JUMP_FORCE,out jumpforce) &&
				distance < 1.1f
			)
				Movement.Jump(obj,jumpforce);
		}
	}

	public static void EnablePlayerTPControl(GameObject obj,Dictionary<string,float> properties) {
		float movespeed;
		if (properties.TryGetValue(PropertyManager.CHARACTER_MOVESPEED,out movespeed)) {
			if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
				Movement.Move(obj,movespeed,Movement.MOVEMENT_FORWARD);
			if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
				Movement.Turn(obj,movespeed,Movement.MOVEMENT_TURN_RIGHT);
			if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
				Movement.Turn(obj,movespeed,Movement.MOVEMENT_TURN_LEFT);
			if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
				Movement.Move(obj,movespeed,Movement.MOVEMENT_BACKWARDS);
		}
	}
}
