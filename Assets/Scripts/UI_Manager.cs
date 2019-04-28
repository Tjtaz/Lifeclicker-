using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject pausePanel;

    public bool pauseOff;
    public GameObject buttonJouer;
    public GameObject endPanel;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            togglePause();
        }
    }

    public void activateEndPanel()
    {
        endPanel.SetActive(true);
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

    // Main Menu

    public void OnClickedButtonPlay()
    {
        SceneManager.LoadScene("CHEF_LD");
    }

    public void OnClickedButtonQuit()
    {
        Application.Quit();
    }

    // Pause Menu

    public void OnClickedResume()
    {
        togglePause();
        buttonJouer.SetActive(false);
    }

    // Pause & End Menu

    public void OnClickedRetry()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void OnClickedMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
