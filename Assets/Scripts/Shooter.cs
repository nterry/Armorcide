using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public Rigidbody bullet;
    //this is purely for debugging
    public bool shoot;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            if (shoot) {
                Rigidbody blt = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
                blt.AddRelativeForce(0.0f, 0.0f, 6000.0f);
            }
        }
	}
}
