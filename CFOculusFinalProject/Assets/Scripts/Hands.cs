using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

    public OVRInput.Controller controller;
    public bool red = false;
    public bool blue = false;
    public int redCharges = 20;
    public int blueCharges = 20;
    public GameObject spawnPoint;
    public GameObject bullet;
    public GameObject Shield;
    public Player player;

    private float fireRate = 0.25f;
    private float fireTimer = 0.25f;

    private void Update()
    {
        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(controller);
        fireTimer -= Time.deltaTime;

        if (red) //RIGHT
        {
            Shield.GetComponent<Renderer>().material.color = new Color((0.8f / 10f * (float)redCharges) + .2f, .2f, .2f, 1f);
            if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") >= 0.9f && redCharges > 0 && fireTimer <= 0)
            {
                Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
                redCharges--;
                fireTimer = fireRate;
            }
        }

        if(blue) //LEFT
        {
            Shield.GetComponent<Renderer>().material.color = new Color(.2f, .2f, (0.8f / 10f * (float)blueCharges) + .2f, 1f);
            if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") >= 0.9f && blueCharges > 0 && fireTimer <= 0)
            {
                Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
                blueCharges--;
                fireTimer = fireRate;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(red)
        {
            if(other.gameObject.tag == "Red")
            {
                redCharges++;
                Destroy(other.gameObject);
                player.score += 10;
            }
        }

        if (blue)
        {
            if (other.gameObject.tag == "Blue")
            {
                blueCharges++;
                Destroy(other.gameObject);
                player.score += 10;
            }
        }
    }
}
