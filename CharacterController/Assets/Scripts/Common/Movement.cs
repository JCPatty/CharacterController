using UnityEngine;
using System.Collections;

public class Movement {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: Strictly a class library, for the purpose of storing movement related functions.
	 *	    A list of voided actions to perform only once without the need to retain any data.
	 */

	public const string MOVEMENT_FORWARD = "forward";
	public const string MOVEMENT_RIGHT = "right";
	public const string MOVEMENT_LEFT = "left";
	public const string MOVEMENT_BACKWARDS = "backwards";

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
}
