using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBullet : MonoBehaviour
{


    public float MoveSpeed = 6.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 4f;   // Size of sine movement

    private float spawnTime = 0f;
    private Vector3 axis;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        axis = transform.up;  // May or may not be the axis you want

    }

    void Update()
    {
        spawnTime += Time.deltaTime;
        pos += transform.forward * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(spawnTime * frequency) * magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
