using UnityEngine;
using System.Collections;

public class Tools {

	/* Author: James Patrick
	 * Date: 26/08/2016
	 * Purpose: This class is strictly for functions to assist with debugging, such as outputting data in
	 *	    a nicer style. This will slowly grow as I become more accustomed to how Unity truly works.
	 */
	
	// Do I REALLY need to go through every data type and make a dump function? Need to look into using type templates.
	public static void dump(string output_string) {Debug.Log(output_string);}

	public static void dump(int output_int) { Debug.Log(output_int); }

	public static void dump(string[] output_string) {
		foreach (string i in output_string)
			Debug.Log(i);
	}

	public static void dump(int[] output_int) {
		foreach (int i in output_int)
			Debug.Log(i);
	}
}
