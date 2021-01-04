using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField] GameObject tutorialUI;
    [SerializeField] GameObject creditUI;

    void Start()
    {
    }

    public void StartGame()
    {
        //start button
        SceneManager.LoadScene("Game");
    }

    public void Tutorial()
    {
        //tutorial button
        tutorialUI.SetActive(true);
    }
    public void Credit()
    {
        //credit button
        creditUI.SetActive(true);
    }

    public void Exit()
    {
        //exit button
        Application.Quit();
    }

    public void tutorialDisable()
    {
        tutorialUI.SetActive(false);
    }

    public void creditDisable()
    {
        creditUI.SetActive(false);
    }

}
