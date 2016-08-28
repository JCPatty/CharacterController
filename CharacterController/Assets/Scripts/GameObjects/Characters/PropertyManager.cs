using UnityEngine;
using System.Collections;

public class PropertyManager {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: Strictly a library class for calculations of damage, health. So far going to group calculations
	 *	    into this class as the list is not large just yet. In time, may need to migrate this to its
	 *	    own class. Stay tuned.
	 */

	// Property names, will forever be adding to this, should just save it in a data file
	public const string CHARACTER_HEALTH = "health";
	public const string CHARACTER_RESOURCE = "resource";
	public const string CHARACTER_MOVESPEED = "movespeed";
	public const string CHARACTER_GRAVITY = "gravity";
	public const string CHARACTER_JUMP_FORCE = "jump_force";
	public const string CHARACTER_JUMP_STATUS = "jump_status";
	public const string CHARACTER_CAMERA_MODE = "camera_mode";

	// Calculation constants
	public const string CALCULATION_ADD = "add";
	public const string CALCULATION_SUBTRACT = "subtract";

	/* Generic name, works for both healing and damage.
	 * @Param1: GameObject - object that will be affected by SendMessage(). Requires object to have UpdateHealth() 
	 *			 as existing function.
	 * @Param2: String - Can either be damage or heal, who knows, someday could add towards shields
	 * @Param3: Integer - Amount in which to add or deduct the health value, based on value of `type`
	 */
	public static void UpdateHealth(GameObject obj, string type, int amount) {

	}

}
