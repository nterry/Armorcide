using UnityEngine;
using System.Collections;

public class Rocket01Pickup : MonoBehaviour {
	
	private int secondsToRotationShift;
	private Vector3 rot;
	
	void Start () {
		secondsToRotationShift = Random.Range(20, 50);
		rot = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
	}
	
	void Update () {
		
		if (secondsToRotationShift == 0) {
			rot = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
			secondsToRotationShift = Random.Range(20, 50);
		}
		else {
			secondsToRotationShift -= 1;	
		}
		transform.Rotate(rot);
		
	}
	
	void OnCollisionEnter(Collision collision) {
		//Destroy (gameObject);
	Debug.Log("yay");
	}
}
