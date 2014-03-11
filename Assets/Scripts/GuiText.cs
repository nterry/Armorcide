using UnityEngine;
using System.Collections;

public class GuiText : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = string.Format("X-Axis: {0}\nY-Axis: {1}", Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}
