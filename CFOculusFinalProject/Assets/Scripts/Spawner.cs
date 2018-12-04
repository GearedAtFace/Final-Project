using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform target;
    public float fireRate = 0.25f;
    public List<GameObject> spawnBullet;
    public List<Vector3> spawnPos;
    private float fireTimer;
    private int i = 0;

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
            if(spawnBullet[i])Instantiate(spawnBullet[i], 
                new Vector3(transform.position.x + (spawnPos[i].x/10), transform.position.y + (spawnPos[i].y/10), transform.position.z),
                transform.rotation);
            fireTimer = fireRate;
            i++;
        }
	}
}
