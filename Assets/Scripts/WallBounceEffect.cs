using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallBounceEffect : MonoBehaviour {

    public List<GameObject> weapons;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        GameObject dupOriginal = weapons.Find(x => x.tag == other.tag);
        Vector3 newDirection = Vector3.Reflect(other.transform.forward, collision.contacts[0].normal);
        GameObject dup = (GameObject) Instantiate(dupOriginal);
        dup.transform.position = other.transform.position;
        dup.transform.localEulerAngles = newDirection;
        dup.rigidbody.AddRelativeForce(0.0f, 0.0f, 6000.0f);
    }
}
