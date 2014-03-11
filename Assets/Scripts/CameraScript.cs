using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {
	
    public static CameraScript Instance { get; private set; }

	private static Queue<GameObject> effectorList;

    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
		effectorList = new Queue<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (effectorList.Count > 0) {
			var effector = effectorList.Dequeue();
			var location = effector.transform;
			
			//Check to see if its an animated texture
			//var script = effector.GetComponent(typeof(AnimatedTexture));
			//if (script != null) {
			//	var screenPoint = camera.WorldToScreenPoint(location.position);
			//	script.SendMessage("SetScreenPosition", new Rect(screenPoint.x - 20, screenPoint.y - 20, 40, 40));
			//	script.SendMessage("Animate");
			//}

            //var screenPoint = camera.WorldToScreenPoint(location.position);
            //.SendMessage("SetScreenPosition", new Rect(screenPoint.x - 20, screenPoint.y - 20, 40, 40));
            effector.SendMessage("Animate");

		}
	}

	public void RegisterEffector(GameObject @object) {
		effectorList.Enqueue(@object);
	}
	
	void OnGUI() {
	}
}
