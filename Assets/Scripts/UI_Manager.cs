using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Singleton;
 

    private void Awake()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
    }
    // Use this for initialization

    void Start()
    {
        //Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

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
    

    // Pause & End Menu

    public void OnClickedRetry()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void OnClickedMainMenu()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
}
