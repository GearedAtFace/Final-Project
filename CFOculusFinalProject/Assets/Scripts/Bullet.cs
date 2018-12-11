using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody rb;
    public int damage = 1;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void Update () {
        rb.velocity = gameObject.transform.forward * 3;
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    public void facePlayer()
    {
        transform.LookAt(GameObject.Find("Main Camera").transform);
    }
}
