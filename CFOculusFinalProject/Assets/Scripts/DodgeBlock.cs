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
    public Text HPText;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void Update()
    {
        rb.velocity = gameObject.transform.forward * 3;
        HPText.text = health.ToString();
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
            if (health <= 0) Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerBlue" && blue)
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0) Destroy(gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().takeDamage(damage);
        }
    }
}
