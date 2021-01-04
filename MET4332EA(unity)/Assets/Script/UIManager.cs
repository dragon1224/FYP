using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]  Text scoreText, healthText, timerText ;
    [SerializeField] Slider healthbar;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject lvupspeed;
    [SerializeField] GameObject lvupbulletspeed;
    [SerializeField] GameObject lvupbulletlife;
    private float startTime;
    void Start()
    {
        GameStatus.health = 200;
        GameStatus.score = 0;
        Time.timeScale = 1f;
        startTime = Time.time;

        healthbar.value = GameStatus.health;
        healthbar.maxValue = GameStatus.health;
        gameOverScreen.SetActive(false);
    }
    void Update()       //auto update UI 
    {
        healthText.text = "Health: " + GameStatus.health;
        scoreText.text = "Score: " + GameStatus.score;
        healthText.text = "Health: " + GameStatus.health;
        healthbar.value = GameStatus.health;

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
    }
    public void Addbulletspeed()
    {
        if (GameStatus.upgradepoint > 0)
            GameStatus.bulletspeed += 5f;
    }
    public void Addbulletlife()
    {
        if (GameStatus.upgradepoint > 0)
            GameStatus.bulletlife += 1f;
    }
    public void Addplayerspeed()
    {
        if (GameStatus.upgradepoint > 0)
            GameStatus.playerspeed += 1f;
    }
}
