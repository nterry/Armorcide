using UnityEngine;
using System;
using System.Collections;
using System.Threading;


public class TankController : MonoBehaviour
{
	public WheelCollider wheel01;
	public WheelCollider wheel02;
	public WheelCollider wheel03;
	public WheelCollider wheel04;
	
	public KeyCode LeftKey;
	public KeyCode RightKey;
	public KeyCode ForwardKey;
	public KeyCode ReverseKey;
	
	public Texture2D HUDTex;
	
    private float speed = 50.0F;
    private float rotate = 100.0F;
	//private float decelerate = 50.0F;
	//private float gravity = -9.8F;
	
	private float massCenter;
	
	void Awake() {
		massCenter = -2.5F;
		rigidbody.centerOfMass = new Vector3(0.0F, massCenter, 0.0F);
	}
	
    void Start() {
    }

    void Update() {
        float rotar = 0.0F;
		if (Input.GetKey(LeftKey)) {
			//Debug.Log ("Left key pressed");
			rotar = -1.0F;
		} else if (Input.GetKey(RightKey)) {
			rotar = 1.0F;
			//Debug.Log ("Right key pressed");
		}
        transform.Rotate(0, rotar * Time.deltaTime * rotate, 0);
	}
	
	void FixedUpdate() {
		float translation = 0.0F;
		if (wheel01.isGrounded || wheel02.isGrounded || wheel03.isGrounded || wheel04.isGrounded){
			if (Input.GetKey(ForwardKey)) {
				translation = 1.0F;
			} else if (Input.GetKey(ReverseKey)) {
				translation = -1.0F;	
			}
			rigidbody.AddRelativeForce(new Vector3(0.0F, 0.0F, translation * speed));
		}
	}	
	
	void OnCollisionEnter(Collision other) {
		//Destroy(other.gameObject);
	}
	
	
	void OnCollisionExit(Collision other) {
	}
		
	void OnGUI() {
		
		
	}
}