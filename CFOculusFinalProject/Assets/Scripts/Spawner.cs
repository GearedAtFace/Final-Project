using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject bullet;
	
	// Update is called once per frame
	void Update () {
        Instantiate(bullet, transform.position, transform.rotation);
	}
}
