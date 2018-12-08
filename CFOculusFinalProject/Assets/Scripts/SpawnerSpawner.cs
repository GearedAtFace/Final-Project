using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour {

    GameObject currentSpawner;
    public Transform spawnPoint;
    public List<GameObject> spawners;
    Player player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Main Camera").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentSpawner == null && !player.dead)
        {
            currentSpawner = Instantiate(spawners[Random.Range(0, spawners.Count)], spawnPoint.position, spawnPoint.rotation);
        }
	}
}
