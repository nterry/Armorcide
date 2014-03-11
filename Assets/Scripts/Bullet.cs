using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Camera cam;
	public GameObject explosion;
    
    private GameObject cameraObj;

	// Use this for initialization
	void Start ()
	{
	    cameraObj = cam.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		//StartCoroutine(WaitDestroy());	
        Destroy(gameObject);
	}
	
	IEnumerator WaitDestroy() {
		yield return new WaitForSeconds(0.05F);
		var g = Instantiate(explosion) as GameObject;
		cameraObj.SendMessage("RegisterEffector", g, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);	
	}
}