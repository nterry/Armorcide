using UnityEngine;
using System.Collections;

public class smoke_puff : MonoBehaviour {
	
	float alpha = 1.0F;
	void Start () {
		//Debug.Log("Hi");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.localScale.x <= 1.0F && transform.localScale.z <= 1.0F) {
			transform.localScale += new Vector3(0.02F, 0.0F, 0.02F);
		} else {
			Destroy(gameObject, 1.0F);
		}
		renderer.materials[0].color = new Color(1.0F, 1.0F, 1.0F, alpha-=0.02F);
	}
}
