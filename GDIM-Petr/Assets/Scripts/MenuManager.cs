using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Canvas Settings;
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            Settings.enabled = true;
        }
    }
}