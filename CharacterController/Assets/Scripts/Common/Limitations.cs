using UnityEngine;
using System.Collections;

public class Limitations : MonoBehaviour {

	public GameObject _barrier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Destroy disposable objects. Once I know how to, add particle effects
	void DestroyObject(Object destroyable_object) {
		Destroy(destroyable_object);
	}

	// Restart the player to the starting position. In future with a real level, use a different spawn point
	void RespawnPlayer(GameObject spawnable_object) {
		// Move player back
		spawnable_object.transform.position = new Vector3(4,1,4);
		// Probably factor in their orientation, they'll end up on their head

	}
}
