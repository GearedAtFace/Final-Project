using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRing : MonoBehaviour {

    public GameObject[] blueBullets = new GameObject[6];
    public GameObject[] redBullets = new GameObject[6];

    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        rb.velocity = gameObject.transform.forward * 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            blueBullets[Random.Range(0, blueBullets.Length)].GetComponent<Bullet>().facePlayer();
            redBullets[Random.Range(0, blueBullets.Length)].GetComponent<Bullet>().facePlayer();
        }
    }
}
