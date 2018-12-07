using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public Image hitSplat;
    public Text healthText;
    public Text GameOver;
    public Text GameTimer;

    private float timer = 0;
    private float gameTimer = 0;
    public bool dead = false;
    private int minutes = 0, seconds = 0;

    private void Start()
    {
        GameOver.color = Color.clear;
    }

    void Update ()
    {
        timer -= Time.deltaTime;

        if (!dead)
        {
            if (seconds >= 60) minutes++;
            seconds = (int)Time.realtimeSinceStartup - (minutes * 60);
            if (seconds < 10)
            {
                GameTimer.text = "Time: " + minutes + ":0" + seconds;
            }
            else GameTimer.text = "Time: " + minutes + ":" + seconds;

            if (timer >= 0)
            {
                hitSplat.color = new Color(Color.red.r, Color.red.g, Color.red.b, (Color.red.a * timer) * 0.4f);
            }
            else hitSplat.color = Color.clear;

            if (timer >= -2)
            {
                healthText.color = new Color(Color.green.r, Color.green.g, Color.green.b, (Color.green.a * (timer + 2)));
            }
            else healthText.color = Color.clear;
        }
    }

    public void takeDamage(int damage)
    {
        if (!dead)
        {
            health -= damage;
            timer = 1;
            healthText.text = "Health: " + health;
            if (health <= 0) die();
        }
    }

    private void die()
    {
        GameOver.color = Color.white;
        dead = true;
    }
}
