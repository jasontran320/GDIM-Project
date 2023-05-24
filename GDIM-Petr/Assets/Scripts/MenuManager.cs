using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Canvas Settings;
    private bool pause;

    private void Start() 
    {
        Settings = Volume.instance.gameObject.GetComponent<Canvas>();
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SwitchSceneWithName(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause)
            {
                pause = false;
                Settings.enabled = false;
                Resume();
            }else
            {
                pause = true;
                Settings.enabled = true;
                Pause();
            }
        }
    }
    
}