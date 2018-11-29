using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform target;
    public float fireRate = 0.1f;
    public GameObject bullet;
    private float fireTimer;

    private void Start()
    {
        fireTimer = fireRate;
    }
    void Update ()
    {
        fireTimer -= Time.deltaTime;
        if(target)transform.LookAt(target);
        if (fireTimer <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            fireTimer = fireRate;
        }
	}
}
