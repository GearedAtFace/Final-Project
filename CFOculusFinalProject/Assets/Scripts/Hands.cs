using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

    public OVRInput.Controller controller;
    public bool red = false;
    public bool blue = false;

    private void Update()
    {
        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(controller);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(red)
        {
            if(other.gameObject.tag == "Red")
            {
                Debug.Log("Reeeee");
                Destroy(other.gameObject);
            }
        }

        if (blue)
        {
            if (other.gameObject.tag == "Blue")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
