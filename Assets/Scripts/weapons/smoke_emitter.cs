using UnityEngine;
using System.Collections;
using System;

public class smoke_emitter : MonoBehaviour {
	
	public Transform smokePuff;

    private System.Random rnd;
	// Use this for initialization
	void Start () {
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        int secondsSinceEpoch = (int)t.TotalSeconds;
        rnd = new System.Random(secondsSinceEpoch);
	}
	
	// Update is called once per frame
	void FixedUpdate () {  
        var rotateY = rnd.Next(0, 179);

        var rot = new Quaternion(0, rotateY, 0, 0);
		var smoke = Instantiate(smokePuff) as Transform;
		smoke.transform.position = transform.position;
        smoke.transform.localRotation = rot;
	}
}