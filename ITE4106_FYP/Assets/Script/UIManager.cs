using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public Text scoreText, healthText, timerText ,levelinfo;
    public TextMeshProUGUI upgradeText,bulletSpeedText,bulletLifeText,playerSpeedText,fireControlText;
    public Slider healthbar;
    public GameObject gameOverScreen;
    public GameObject lvupbulletspeed;
    public GameObject lvupbulletlife;
    public GameObject lvupspeed;
    public GameObject lvupfp;
    public GameObject menu;
    private float startTime;

    void Start()
    {
        GameStatus.health = 200;
        GameStatus.score = 0;
        GameStatus.menuIsOn = false;
        GameStatus.lv = 1;
        GameStatus.currentexp = 5;
        GameStatus.maxexp = 5;
        Time.timeScale = 1f;
        startTime = Time.time;

        healthbar.value = GameStatus.health;
        healthbar.maxValue = GameStatus.health;
        gameOverScreen.SetActive(false);
    }
    void FixedUpdate()       //auto update UI 
    {
        //menu
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameStatus.menuIsOn == false)
            {
                GameStatus.menuIsOn = true;
                menu.SetActive(true);
            }
            else
            {
                GameStatus.menuIsOn = false;
                menu.SetActive(false);
            }
        }

        healthText.text = "Health: " + GameStatus.health;
        scoreText.text = "Score: " + GameStatus.score;
        healthText.text = "Health: " + GameStatus.health;
        healthbar.value = GameStatus.health;
        levelinfo.text = "Lv" + GameStatus.lv + " " + GameStatus.currentexp +"/"+ GameStatus.maxexp; 
        upgradeText.text = "Upgrade Point :" + GameStatus.upgradepoint;
        bulletSpeedText.text = "Bullet Speed : " + GameStatus.bulletspeed;
        bulletLifeText.text = "Bullet Life : " + GameStatus.bulletlife;
        playerSpeedText.text = "Player Speed : " + GameStatus.playerspeed;
        fireControlText.text = "Fire Control : " + GameStatus.firecontrol;

        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds ;

        //gameover
        if (GameStatus.health <= 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
        if(GameStatus.currentexp >= GameStatus.maxexp)
        {
            GameStatus.currentexp -= GameStatus.maxexp;
            GameStatus.maxexp += GameStatus.lv;
            GameStatus.lv += 1;
            GameStatus.upgradepoint += 2;
        }
    }
    public void Addbulletspeed()
    {
        if (GameStatus.upgradepoint > 0)
        {
        GameStatus.bulletspeed += 1.0f;
        GameStatus.upgradepoint -= 1;
        }
    }
    public void Addbulletlife()
    {
        if (GameStatus.upgradepoint > 0)
        { 
        GameStatus.bulletlife += 0.1f;
        GameStatus.upgradepoint -= 1;
        }
    }
    public void Addplayerspeed()
    {
        if (GameStatus.upgradepoint > 0)
        {
            GameStatus.playerspeed += 1f;
            GameStatus.upgradepoint -= 1;
        }
    }

    public void AddFireControl()
    {
        if (GameStatus.upgradepoint > 0 & GameStatus.firecontrol > 0)
        {
            GameStatus.firecontrol -= 1;
            GameStatus.upgradepoint -= 1;
        }
    }
}
