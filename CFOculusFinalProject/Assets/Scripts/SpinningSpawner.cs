using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSpawner : MonoBehaviour {

    public float fireRate = 0.1f;
    public Vector3 spinSpeed;
    public GameObject bullet;
    private float fireTimer;
	// Use this for initialization
	void Start ()
    {
        fireTimer = fireRate;
    }
	
	// Update is called once per frame
	void Update ()
    {
        fireTimer -= Time.deltaTime;
        transform.Rotate(spinSpeed);
        if (fireTimer <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            fireTimer = fireRate;
        }
    }
}
