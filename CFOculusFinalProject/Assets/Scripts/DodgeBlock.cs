using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodgeBlock : MonoBehaviour {

    Rigidbody rb;
    public bool red;
    public bool blue;
    public int health = 5;
    public int damage = 1;
    public TextMesh HPText;

    private Player player;
    private bool gavePoints = false;
    private bool hitPlayer = false;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        player = GameObject.Find("Main Camera").GetComponent<Player>();
    }
    void Update()
    {
        rb.velocity = gameObject.transform.forward * 3;
        if(blue || red) HPText.text = health.ToString();
        if (!blue && !red && !gavePoints && transform.position.z < 0 && !hitPlayer)
        {
            gavePoints = true;
            player.score += 50;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerRed" && red)
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
                player.score += 100;
            }
        }

        if (other.gameObject.tag == "PlayerBlue" && blue)
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
                player.score += 100;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hitPlayer = true;
            other.gameObject.GetComponent<Player>().takeDamage(damage);
        }
    }
}
