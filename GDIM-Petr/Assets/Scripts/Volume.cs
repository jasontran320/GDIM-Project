using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider = null;
    [SerializeField]
    private Slider sfxSlider = null;
    private bool pause = false;
    private string nam = "BG Music";
    public static Volume instance;
    
    private void Awake() {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
 
    public void Pause()
    {
        if(pause)
        {
            pause = false;
        }else
        {
            pause = true;
        }
        AudioManager.instance.Pause(nam, pause);
    }

    private void Update() 
    {

        AudioManager.instance.Volume(nam, musicSlider.value);

        for(int i = 1; i < AudioManager.instance.sounds.Length; i++) 
        {
            Sound s = AudioManager.instance.sounds[i];
            AudioManager.instance.Volume(s.name, sfxSlider.value);
        }    
    }

    public void Quit()
    {
        Application.Quit();
    }


}
