using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public int score = 0;
    public Image hitSplat;
    public Text healthText;
    public Text GameOver;
    public Text GameTimer;
    public Text HUDScore;
    public Text start;
    public Hands leftHand, rightHand;

    private float timer = 0;
    private float startTime = 0;
    public bool dead = false;
    private int minutes = 0, seconds = 0;

    private void Start()
    {
        GameOver.color = Color.clear;
        healthText.color = Color.clear;
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

            HUDScore.text = "Score: " + score;
        }
        else
        {
            if(Input.GetButton("Fire1"))
            {
                dead = false;
                start.color = Color.clear;
                start.text = "Press A to restart";
                startTime = Time.realtimeSinceStartup;
                unDie();
            }
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
        start.color = Color.white;
    }

    public void unDie()
    {
        dead = false;
        health = 100f;
        timer = 0;
        minutes = 0;
        seconds = 0;
        leftHand.blueCharges = 20;
        rightHand.redCharges = 20;
        GameOver.color = Color.clear;
    }
}
