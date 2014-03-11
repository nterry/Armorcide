using UnityEngine;
using System.Collections;

public class Rocket01 : WeaponBase {

    public Transform explosion;

    private float timer;
    private bool isKickstarted = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.fixedDeltaTime;
        if (timer > 0.025F && !isKickstarted) KickStart();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (IsResponsive())
        {
            var g = Instantiate(explosion) as Transform;
            g.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    void KickStart()
    {
        isKickstarted = true;
        SetResponsive(true);
    }
}
