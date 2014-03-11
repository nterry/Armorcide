using UnityEngine;
using System.Collections;
using Pathfinding;

public class TestAi : MonoBehaviour {

	public Vector3 targetPosition;
	public void Start () {
		//Get a reference to the Seeker component we added earlier
		Seeker seeker = GetComponent<Seeker>();
		
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath (transform.position, targetPosition, OnPathComplete);

		Debug.Log ( string.Format ("Path Details: {0} -> {1}", transform.position, targetPosition));
	}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
	}
}
