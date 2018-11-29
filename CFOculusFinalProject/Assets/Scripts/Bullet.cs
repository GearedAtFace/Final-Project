using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void Update () {
        rb.velocity = gameObject.transform.forward;
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
