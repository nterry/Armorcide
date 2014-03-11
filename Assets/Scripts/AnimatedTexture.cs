using UnityEngine;
using System.Collections;
using System.Threading;

public class AnimatedTexture : MonoBehaviour {
	
	public Texture2D[] frames;
	public bool repeat;
    public MeshRenderer textureRenderer;
	
	private int currentFrame;
	private Thread animateIteratorThread;
	private bool animate;
	private Rect position;

    
	
	// Use this for initialization
	void Start () {
		animateIteratorThread = new Thread(Iterate);
		animate = false;
        currentFrame = 0;
        Animate();
	}

	void SetScreenPosition(Rect rect) {
        transform.position = new Vector3(rect.x, transform.position.y, rect.y);
		position = rect;
	}

	void Animate() {
		animateIteratorThread.Start();
		animate = true;
	}

	// Update is called once per frame
	void Update () {
		if (animate == false) return;
		if (repeat) {
            if (currentFrame >= (frames.Length))
            {
                Destroy(gameObject);
                animate = false;
                animateIteratorThread.Abort();
            }
            else
            {
                textureRenderer.material.SetTexture("_MainTex", frames[currentFrame]);
            }
		}
	}

	private void Iterate() {
		while(currentFrame < frames.Length) {
			currentFrame += 1;
			Thread.Sleep(45);
		}
	}
}
